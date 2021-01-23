using System;

namespace Employer.CLI
{
    public static class UserInteraction
    {
        
        public static string AskAnQuestion(string field)
        {
            Console.Write($"Insira o {field}: ");
            return Console.ReadLine();
        }
        
        public static void PressToBackToMenu()
        {
            Console.WriteLine("Aperte Enter para voltar ao Menu.");
            Console.ReadLine();
        }
        
    }
}