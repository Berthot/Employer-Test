using System;
using System.Collections.Generic;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class Student
    {
        public Student(Name name, Cpf cpf, string course, Date birthDate)
        {
            Name = name;
            Cpf = cpf;
            Course = course;
            BirthDate = birthDate;
            CreateAt = DateTime.Now;
        }

        public Student()
        {
            
        }

        public int Id { get; set; }
        
        public Name Name { get; set; }
        
        public Cpf Cpf { get; set; }
        
        public string Course { get; set; }
        
        public Date BirthDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        public List<StudentSubjectMap> StudentSubjectMaps { get; set; }
    }
}