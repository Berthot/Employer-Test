using Employer.CLI.CLI;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class NoteService
    {
        public void RegisterNewSubject()
        {
            var noteDto = GetNoteDto();
            UserInteraction.MenuOption();
            var option = UserInteraction.MenuOption();
            switch (option)
            {
                case "2":
                    SaveNote(noteDto);
                    return;
                case "3":
                    DeleteNote(noteDto);
                    return;
            }
        }
        
        private void SaveNote(NoteDto noteDto)
        {
            
        }
        
        private void DeleteNote(NoteDto noteDto)
        {
            
        }

        private static NoteDto GetNoteDto()
        {
            var student = UserInteraction.FieldToFill("Nome do aluno");
            var subject = UserInteraction.FieldToFill("Matéria");
            var note = UserInteraction.FieldToFill("Nota entre (0-100)");
            return new NoteDto(student, subject, note);
        }
    }
}