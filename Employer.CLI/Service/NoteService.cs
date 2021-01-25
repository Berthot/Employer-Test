using System;
using System.Collections.Generic;
using Employer.CLI.CLI;
using Employer.CLI.Controller;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class NoteService
    {
        
        private readonly NoteController _controller = new NoteController();

        public void RegisterNewSubject()
        {
            var noteDto = GetNoteDto();
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
            var response = _controller.CreateNote(noteDto);
            if (response.GetType() == new NoteDto().GetType())
            {
                Console.WriteLine($"Cadastro da nota do aluno realizado com sucesso.");
                UserInteraction.PressToBackToMenu();
            }
            else
            {
                var lista = (List<string>) response;
                foreach (var bad in lista)
                {
                    Console.WriteLine($"ERR: {bad}");
                }
                Console.WriteLine("Erro ao cadastrar nota do aluno");
                UserInteraction.PressToBackToMenu();

            }
        }
        
        private void DeleteNote(NoteDto noteDto)
        {
            var response = _controller.DeleteNote(noteDto);
            var lista = (List<string>) response;
            foreach (var bad in lista)
            {
                Console.WriteLine($"{bad}");
            }
            UserInteraction.PressToBackToMenu();
        }

        private static NoteDto GetNoteDto()
        {
            var student = UserInteraction.FieldToFill("Nome do aluno");
            var studentCpf = UserInteraction.FieldToFill("Cpf do aluno");
            var subject = UserInteraction.FieldToFill("Matéria");
            var note = UserInteraction.FieldToFill("Nota entre (0 e 100)");
            return new NoteDto(student, subject, note, studentCpf);
        }
    }
}