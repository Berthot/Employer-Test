using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class StudentSubjectMap
    {
        
        public int Id { get; set; }
        
        public Note Note { get; set; }
        public int StudentId { get; set; }
        
        public int SubjectId { get; set; }
        
        public int UpdateAt { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}