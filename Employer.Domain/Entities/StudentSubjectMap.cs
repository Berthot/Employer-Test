using System;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.Entities
{
    public class StudentSubjectMap
    {
        public StudentSubjectMap()
        {
        }

        public StudentSubjectMap(Student student, Subject subject, Note note)
        {
            Note = note;
            Subject = subject;
            Student = student;
        }

        public int Id { get; set; }
        
        public Note Note { get; set; }
        public int StudentId { get; set; }
        
        public int SubjectId { get; set; }
        
        public DateTime UpdateAt { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}