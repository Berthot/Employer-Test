using System;
using System.Globalization;
using Employer.Domain.Entities;

namespace Employer.Domain.DTO
{
    public class SubjectDto
    {
        public SubjectDto(string description, string situation, string registrationDate)
        {
            Description = description;
            Situation = situation;
            RegistrationDate = registrationDate;
        }

        public SubjectDto()
        {
        }

        public SubjectDto(Subject subjectModel)
        {
            Id = subjectModel.Id.ToString();
            Description = subjectModel.Description.Name;
            Situation = subjectModel.Situation.ToString();
            RegistrationDate = subjectModel.RegistrationDate.Code.ToString(CultureInfo.CurrentCulture);
            CreateAt = subjectModel.CreateAt;
            UpdateAt = subjectModel.UpdateAt;
        }


        public string Id { get; set; }
        
        public string Description { get; set; }
        
        public string Situation { get; set; }
        
        public string RegistrationDate { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
    }
}