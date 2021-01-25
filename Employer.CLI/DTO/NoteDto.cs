namespace Employer.CLI.DTO
{
    public class NoteDto
    {
        public NoteDto(string student, string description, string note, string studentCpf)
        {
            Student = student;
            Description = description;
            Note = note;
            StudentCpf = studentCpf;
        }

        public NoteDto()
        {
        }

        public string Student { get; set; }
        public string StudentCpf { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}