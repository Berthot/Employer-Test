namespace Employer.CLI.DTO
{
    public class NoteDto
    {
        public NoteDto(string student, string subjectName, string note, string studentCpf)
        {
            Student = student;
            SubjectName = subjectName;
            Note = note;
            StudentCpf = studentCpf;
        }

        public string Student { get; set; }
        
        public string StudentCpf { get; set; }
        public string SubjectName { get; set; }
        public string Note { get; set; }
    }
}