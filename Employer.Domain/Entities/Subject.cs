using System;
using System.Collections.Generic;
using Employer.Domain.Enum;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        
        public Description Description { get; set; }
        
        public ESituation Situation { get; set; }
        public Date RegistrationDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        public IEnumerable<StudentSubjectMap> StudentSubjectMaps { get; set; }
    }
}