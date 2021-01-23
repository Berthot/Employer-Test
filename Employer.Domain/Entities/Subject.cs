using System;
using System.Collections.Generic;

namespace Employer.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public bool Situation { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        public IEnumerable<StudentSubjectMap> StudentSubjectMaps { get; set; }
    }
}