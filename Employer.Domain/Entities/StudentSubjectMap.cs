namespace Employer.Domain.Entities
{
    public class StudentSubjectMap
    {
        
        public int Id { get; set; }
        
        public int Note { get; set; }
        public int StudentId { get; set; }
        
        public int SubjectId { get; set; }
        
        public int UpdateAt { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}