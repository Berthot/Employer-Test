using System;
using System.Collections.Generic;
using Employer.Domain.Enum;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class Subject
    {
        public Subject()
        {
        }

        public Subject(Description description, ESituation situation, Date registrationDate)
        {
            Description = description;
            Situation = situation;
            RegistrationDate = registrationDate;
        }

        public int Id { get; set; }
        
        //TODO remover nome
        public string Name { get; set; }
        
        public Description Description { get; set; }
        
        public ESituation Situation { get; set; }
        public Date RegistrationDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        public IEnumerable<StudentSubjectMap> StudentSubjectMaps { get; set; }
    }
}