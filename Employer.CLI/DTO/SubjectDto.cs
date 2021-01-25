namespace Employer.CLI.DTO
{
    public class SubjectDto
    {
        public SubjectDto()
        {
        }

        public SubjectDto(string description, string date, string situation)
        {
            Description = description;
            RegistrationDate = date;
            Situation = situation;
        }

        public string Id { get; set; }
        
        public string Description { get; set; }
        
        public string Situation { get; set; }
        
        public string RegistrationDate { get; set; }
        
        public string CreateAt { get; set; }
        
        public string UpdateAt { get; set; }
        
    }
}