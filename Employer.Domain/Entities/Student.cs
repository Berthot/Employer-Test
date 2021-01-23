using System;
using System.Collections.Generic;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        
        public Name Name { get; set; }
        
        public Cpf Cpf { get; set; }
        
        public string Course { get; set; }
        
        public Date BirthDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        public IEnumerable<StudentSubjectMap> StudentSubjectMaps { get; set; }
    }
}