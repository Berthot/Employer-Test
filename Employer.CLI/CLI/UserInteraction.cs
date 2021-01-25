using System;
using Employer.CLI.DTO;

namespace Employer.CLI.CLI
{
    public static class UserInteraction
    {
        
        public static string AskAnQuestion(string field)
        {
            Console.Write($"Insira o {field}: ");
            return Console.ReadLine();
        }
        
        public static string FieldToFill(string field)
        {
            Console.Write($"{field}: ");
            return Console.ReadLine();
        }
        
        public static void PressToBackToMenu()
        {
            Console.WriteLine("Aperte Enter para voltar ao Menu.");
            Console.ReadLine();
        }

        public static string MenuOption()
        {
            const int chanceToTry = 3;
            for (var i = 0; i < chanceToTry; i++)
            {
                Console.WriteLine("(1) - Voltar | (2) - Salvar | (3) - Excluir.");
                var response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response) && "123".Contains(response.Substring(0, 1)))
                    return response;
                Console.WriteLine();
            }
            return "1";
        }
        
        public static string MenuOptionTwo()
        {
            const int chanceToTry = 3;
            for (var i = 0; i < chanceToTry; i++)
            {
                Console.WriteLine("(1) - Voltar | (2) - Visualizar ");
                var response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response) && "12".Contains(response.Substring(0, 1)))
                    return response;
                Console.WriteLine();
            }
            return "1";
        }
        
    }
}