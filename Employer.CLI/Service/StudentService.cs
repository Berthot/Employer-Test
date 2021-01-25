using System;
using System.Collections.Generic;
using System.Linq;
using Employer.CLI.CLI;
using Employer.CLI.Controller;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class StudentService
    {

        private readonly StudentController _controller = new StudentController();
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

        public void GetStudentNote()
        {
            var studentNoteDto = GetStudentNotesDto();
            var option = UserInteraction.MenuOptionTwo();
            switch (option)
            {
                case "2":
                    ShowStudentNotes(studentNoteDto);
                    return;
            }
        }

        private void ShowStudentNotes(string studentNoteDto)
        {
            var response = _controller.GetStudentNoteByCpf(studentNoteDto);
            if (response.GetType() == new List<StudentNotesDto>().GetType())
            {
                var obj = (List<StudentNotesDto>) response;
                var studentNotesDtos = obj.OrderBy(x => x.Description);
                var last = "";
                foreach (var map in studentNotesDtos)
                {
                    if (last != map.Description)
                    {
                        last = map.Description;
                        Console.WriteLine($"------------    {map.Description.ToUpper()}    ------------");
                    }

                    Console.WriteLine($"Nota: {map.Note}");
                }
                UserInteraction.PressToBackToMenu();
            }
            else
            {
                var lista = (List<string>) response;
                foreach (var bad in lista)
                {
                    Console.WriteLine($"ERR: {bad}");
                }
                Console.WriteLine("Erro ao ler dados do aluno");
                UserInteraction.PressToBackToMenu();

            }
        }

        private void SaveStudent(StudentDto studentDto)
        {
            var response = _controller.CreateNewStudentPost(studentDto);
            if (response.GetType() == new StudentDto().GetType())
            {
                var obj = (StudentDto) response;
                Console.WriteLine($"Cadastro de aluno realizado com sucesso numero de matricula [ {obj.Id.ToString()} ]");
                UserInteraction.PressToBackToMenu();
            }
            else
            {
                var lista = (List<string>) response;
                foreach (var bad in lista)
                {
                    Console.WriteLine($"ERR: {bad}");
                }
                Console.WriteLine("Erro ao cadastrar aluno");
                UserInteraction.PressToBackToMenu();

            }

        }
        
        private void DeleteStudent(StudentDto studentDto)
        {
            var response = _controller.DeleteStudent(studentDto);
            var lista = (List<string>) response;
            foreach (var bad in lista)
            {
                Console.WriteLine($"{bad}");
            }
            UserInteraction.PressToBackToMenu();

        }
        private string GetStudentNotesDto()
        {
            return UserInteraction.FieldToFill("Cpf - (somente os numeros)");
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