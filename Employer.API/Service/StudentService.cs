using System;
using System.Collections.Generic;
using Employer.Domain.DTO;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
using Employer.Infra.Data;
using Employer.Infra.Repository;

namespace Employer.API.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _repo = new StudentRepository(new Context());

        
        public Student BuildStudent(StudentDto studentDto)
        {
            return new Student(
                new Name(studentDto.Name, studentDto.Surname),
                new Cpf(studentDto.Cpf),
                studentDto.Course,
                new Date(studentDto.BirthDate)
            );
        }


        public List<string> ValidateCreateStudent(Student studentModel)
        {

            var badRequest = new List<string>();
            if (studentModel.Cpf.NotValidate())
                badRequest.Add("Cpf não valido");
            if (studentModel.Name.NotValidateFirstName())
                badRequest.Add("Primeiro nome não é valido, somente letras são permitidas");            
            if (studentModel.Name.NotValidateFirstNameLenght())
                badRequest.Add("Primeiro nome não é valido, tamanho maximo de acima de 50 caracteres");
            if (studentModel.Name.NotValidateSurname())
                badRequest.Add("Sobrenome acima de 50 caracteres");
            if (studentModel.BirthDate.NotValidateDateFormat())
                badRequest.Add("Formato da data esta preenchido incorretamente modelo [ DD/MM/AAAA ] ");
            if (studentModel.BirthDate.NotValidateDate())
                badRequest.Add("Data informada superior á [ 01/01/2002 ] ");
            if (GetStudentByCpf(studentModel.Cpf.Code) != default)
                badRequest.Add("Cpf ja esta cadastro no sistema");
            return badRequest;
        }
        

        public Student GetStudentByCpf(string cpfCode)
        {
            return _repo.GetStudentByCpf(cpfCode);
        }
        

        public StudentDto StudentToDtoStudent(Student studentModel)
        {
            return new StudentDto(studentModel);
        }

        public Student GetStudentToDelete(StudentDto studentDto)
        {
            try
            {
                var cpf = new Cpf(studentDto.Cpf);
                return GetStudentByCpf(cpf.Code);
            }
            catch (Exception)
            {
                return default;
            }

        }
    }
}