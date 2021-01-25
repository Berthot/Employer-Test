using System;
using System.Collections.Generic;
using Employer.CLI.CLI;
using Employer.CLI.Controller;
using Employer.CLI.DTO;

namespace Employer.CLI.Service
{
    public class SubjectService
    {
        private readonly SubjectController _controller = new SubjectController();

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
        
        private void SaveSubject(SubjectDto subjectDto)
        {
            var response = _controller.CreateNewSubject(subjectDto);
            if (response.GetType() == new SubjectDto().GetType())
            {
                var obj = (SubjectDto) response;
                Console.WriteLine($"Cadastro da materia realizado com sucesso numero de matricula [ {obj.Id.ToString()} ]");
                UserInteraction.PressToBackToMenu();
            }
            else
            {
                var lista = (List<string>) response;
                foreach (var bad in lista)
                {
                    Console.WriteLine($"ERR: {bad}");
                }
                Console.WriteLine("Erro ao cadastrar materia");
                UserInteraction.PressToBackToMenu();

            }
        }
        
        private void DeleteSubject(SubjectDto subjectDto)
        {
            var response = _controller.DeleteSubject(subjectDto);
            var lista = (List<string>) response;
            foreach (var bad in lista)
            {
                Console.WriteLine($"{bad}");
            }
            UserInteraction.PressToBackToMenu();
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