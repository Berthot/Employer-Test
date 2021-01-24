using System;

namespace Employer.CLI.DTO
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Course { get; set; }
        
        public DateTime CreatAt { get; set; }
    }
}