using System;
using System.Collections.Generic;
using Employer.Domain.DTO;
using Employer.Domain.Entities;
using Employer.Domain.Enum;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
using Employer.Infra.Data;
using Employer.Infra.Repository;

namespace Employer.API.Service
{
    public class SubjectService
    {
        private readonly ISubjectRepository _repo = new SubjectRepository(new Context());


        public List<string> ValidateEmptyField(SubjectDto subjectDto)
        {
            var badRequest = new List<string>();
            if (subjectDto.Description.Length == 0)
                badRequest.Add("Matéria esta vazio");
            if (subjectDto.Situation.Length == 0)
                badRequest.Add("Situação esta vazio");
            if (subjectDto.RegistrationDate.Length == 0)
                badRequest.Add("Data esta vazio");
            return badRequest;
        }
        public Subject BuildSubject(SubjectDto subjectDto)
        {
            return new Subject(
                new Description(subjectDto.Description.ToLower()),
                GetSituationByString(subjectDto.Situation),
                new Date(subjectDto.RegistrationDate)
            );
        }

        private ESituation GetSituationByString(string situation)
        {
            return situation.ToLower() switch
            {
                "ativo" => ESituation.Active,
                "inativo" => ESituation.Inactive,
                _ => ESituation.NotValid
            };
        }
        
        private string SetSituationString(ESituation situation)
        {
            return situation switch
            {
                ESituation.Active => "ativo",
                ESituation.Inactive => "inativo",
                _ => ""
            };
        }

        public List<string> ValidateCreateSubject(Subject subjectModel)
        {
            // TODO verificar tabela no banco description com len maximo 50
            var badRequest = new List<string>();
            if (subjectModel.Description.NotValidateDescription())
                badRequest.Add("Campo descrição esta invalido, deve ser somente letras, e menos de 50 caracteres.");
            if (subjectModel.RegistrationDate.NotValidateDateFormat())
                badRequest.Add("Formato da data esta preenchido incorretamente modelo [ DD/MM/AAAA ]. ");
            if (subjectModel.RegistrationDate.NotValidateDateSubject())
                badRequest.Add("Data informada superior á atual.");
            if(subjectModel.Situation == ESituation.NotValid)
                badRequest.Add("Preencher com [ Inativo ] ou [ Ativo ]");
            if(GetSubjectByDescription(subjectModel.Description.Name) != default)
                badRequest.Add("O nome desta Materia ja esta cadastrada no sistema");
            return badRequest;
        }

        private Subject GetSubjectByDescription(string descriptionName)
        {
            return _repo.GetSubjectByDescription(descriptionName);
        }

        public SubjectDto SubjectToDtoSubject(Subject subjectModel)
        {
            return new SubjectDto(subjectModel);
        }

        public Subject GetSubjectToDelete(SubjectDto subjectDto)
        {
            try
            {
                return GetSubjectByDescription(subjectDto.Description.ToLower());
            }
            catch (Exception)
            {
                return default;
            }
        }

        public void CreateSubject(Subject subjectModel)
        {
            _repo.CreateSubject(subjectModel);
        }

        public void DeleteSubject(Subject subjectModel)
        {
            _repo.DeleteSubject(subjectModel);
        }
    }
}