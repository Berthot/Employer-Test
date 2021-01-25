using Employer.Domain.Entities;

namespace Employer.Domain.DTO
{
    public class NoteDto
    {
        public NoteDto()
        {
        }

        public NoteDto(StudentSubjectMap studentSubjectMap)
        {
            Student = studentSubjectMap.Student.Name.GetFullName();
            Description = studentSubjectMap.Subject.Description.Name.ToString();
            Note = studentSubjectMap.Note.Value.ToString();
        }

        public string Student { get; set; }
        public string StudentCpf { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}