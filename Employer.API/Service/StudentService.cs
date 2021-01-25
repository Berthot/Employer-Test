using System;
using System.Collections.Generic;
using System.Linq;
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
                new Name(studentDto.Name.ToLower(), studentDto.Surname.ToLower()),
                new Cpf(studentDto.Cpf),
                studentDto.Course.ToLower(),
                new Date(studentDto.BirthDate)
            );
        }

        public List<string> ValidateFieldEmpty(StudentDto studentDto)
        {
            var badRequest = new List<string>();
            if (studentDto.Name.Length == 0)
                badRequest.Add("Name esta vazio");
            if (studentDto.Cpf.Length == 0)
                badRequest.Add("Cpf esta vazio");
            if (studentDto.Course.Length == 0)
                badRequest.Add("Course esta vazio");
            if (studentDto.BirthDate.Length == 0)
                badRequest.Add("BirthDate esta vazio");
            return badRequest;
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
                badRequest.Add("Data informada deve ser superior á [ 01/01/2002 ] ");
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

        public List<StudentNotesDto> GetAllStudentNotes(string cpf)
        {
            var student = GetFullStudentByCpf(cpf);
            return student?.StudentSubjectMaps
                .Select(map => new StudentNotesDto(map.Subject.Description.Name, map.Note)).ToList();
        }

        private Student GetFullStudentByCpf(string cpf)
        {
            return _repo.GetStudentFullByCpf(cpf);
        }

        public void CreateStudent(Student studentModel)
        {
            _repo.CreateStudent(studentModel);
        }

        public void DeleteStudent(Student studentModel)
        {
            _repo.DeleteStudent(studentModel);
        }
    }

}
