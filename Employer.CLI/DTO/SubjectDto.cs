using System;

namespace Employer.CLI.DTO
{
    public class SubjectDto
    {
        public SubjectDto(string description, string situation, string registrationDate)
        {
            Description = description;
            Situation = situation;
            RegistrationDate = registrationDate;
        }

        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string Situation { get; set; }
        
        public string RegistrationDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
    }
}