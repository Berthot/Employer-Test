using System;

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
                        break;
                    case "2": // (2) Cadastro de materia:
                        break;
                    case "3": // (3) Cadastro de Nota:
                        break;
                    case "4": // (4) Visualização de notas do aluno:
                        break;
                    case "5": // (5) Relatorios:
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}