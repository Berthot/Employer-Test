using System;
using Employer.CLI.Application;
using Employer.CLI.CLI;
using Employer.CLI.Service;

namespace Employer.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = "";
            while (option != "0")
            {
                Menu.ShowMainMenu();
                Console.Write("Opção: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1": // (1) Cadastro de aluno:
                        new StudentApplication().RegisterNewStudent();
                        break;
                    case "2": // (2) Cadastro de materia:
                        new SubjectService().RegisterNewSubject();
                        break;
                    case "3": // (3) Cadastro de Nota:
                        new NoteService().RegisterNewSubject();
                        break;
                    case "4": // (4) Visualização de notas do aluno:
                        new StudentApplication().GetStudentNotes();
                        break;
                    // case "5": // (5) Relatorios:
                    //     break;
                    default:
                        continue;
                }
            }
        }
    }
}