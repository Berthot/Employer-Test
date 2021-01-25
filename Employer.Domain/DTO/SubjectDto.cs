using Employer.Domain.Entities;
using Employer.Domain.Enum;

namespace Employer.Domain.DTO
{
    public class SubjectDto
    {

        public SubjectDto()
        {
        }

        public SubjectDto(Subject subjectModel)
        {
            Id = subjectModel.Id.ToString();
            Description = subjectModel.Description.Name;
            Situation = SetSituationString(subjectModel.Situation);
            RegistrationDate = subjectModel.RegistrationDate.Code.Date.ToString();
            CreateAt = subjectModel.CreateAt.Date.ToString();
            UpdateAt = subjectModel.UpdateAt.Date.ToString();
        }



        public string Id { get; set; }
        
        public string Description { get; set; }
        
        public string Situation { get; set; }
        
        public string RegistrationDate { get; set; }
        
        public string CreateAt { get; set; }
        
        public string UpdateAt { get; set; }
        
        private string SetSituationString(ESituation situation)
        {
            return situation switch
            {
                ESituation.Active => "ativo",
                ESituation.Inactive => "inativo",
                _ => ""
            };
        }
    }
}