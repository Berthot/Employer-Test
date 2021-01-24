namespace Employer.CLI.DTO
{
    public class NoteDto
    {
        public NoteDto(string student, string subjectName, string note)
        {
            Student = student;
            SubjectName = subjectName;
            Note = note;
        }

        public string Student { get; set; }
        public string SubjectName { get; set; }
        public string Note { get; set; }
    }
}