using System;
using Employer.Domain.Entities;

namespace Employer.Domain.DTO
{
    public class StudentDto
    {
        public StudentDto(string name, string surname, string birthDate, string cpf, string course)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Cpf = cpf;
            Course = course;
        }

        public StudentDto()
        {
        }

        public StudentDto(Student student)
        {
            Id = student.Id;
            Name = student.Name.FirstName;
            Surname = student.Name.Surname;
            BirthDate = student.BirthDate.Code.ToString();
            Cpf = student.Cpf.Code;
            Course = student.Course;
            CreatAt = student.CreateAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Course { get; set; }
        
        public DateTime CreatAt { get; set; }
    }
}