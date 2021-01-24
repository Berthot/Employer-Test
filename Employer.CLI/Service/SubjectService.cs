using Employer.CLI.CLI;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class SubjectService
    {
        public void RegisterNewSubject()
        {
            var subjectDto = GetSubjectDto();
            var option = UserInteraction.MenuOption();
            switch (option)
            {
                case "2":
                    SaveSubject(subjectDto);
                    return;
                case "3":
                    DeleteSubject(subjectDto);
                    return;
            }
        }
        
        private void SaveSubject(SubjectDto studentDto)
        {
            
        }
        
        private void DeleteSubject(SubjectDto studentDto)
        {
            
        }

        private static SubjectDto GetSubjectDto()
        {
            var description = UserInteraction.FieldToFill("Descrição");
            var date = UserInteraction.FieldToFill("Data do cadastro - (DD/MM/AAAA)");
            var situation = UserInteraction.FieldToFill("Situação - (ativo ou inativo)");
            return new SubjectDto(description, date, situation);
        }
    }
}