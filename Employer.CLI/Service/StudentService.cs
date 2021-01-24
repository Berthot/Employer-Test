using Employer.CLI.CLI;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class StudentService
    {

        public void RegisterNewStudent()
        {
            var studentDto = GetStudentDTO();
            var option = UserInteraction.MenuOption();
            switch (option)
            {
                case "2":
                    SaveStudent(studentDto);
                    return;
                case "3":
                    DeleteStudent(studentDto);
                    return;
            }
        }

        private void SaveStudent(StudentDto studentDto)
        {
            
        }
        
        private void DeleteStudent(StudentDto studentDto)
        {
            
        }

        private StudentDto GetStudentDTO()
        {
            var firstName = UserInteraction.FieldToFill("Nome");
            var surname = UserInteraction.FieldToFill("Sobrenome");
            var birthDate = UserInteraction.FieldToFill("Data de nascimento - (DD/MM/AAAA)");
            var cpf = UserInteraction.FieldToFill("Cpf - (somente os numeros)");
            var course = UserInteraction.FieldToFill("Curso");

            return new StudentDto(firstName, surname, birthDate, cpf, course);
        }
    }
}