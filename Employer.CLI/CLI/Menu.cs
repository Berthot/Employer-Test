using System;
using System.Collections.Generic;

namespace Employer.CLI.CLI
{
    public static class Menu
    {
        public static void ShowMainMenu(int textLenght = 80)
        {
            var text = new List<string>()
            {
                " (1) Cadastro de aluno",
                " (2) Cadastro de materia",
                " (3) Cadastro de Nota",
                " (4) Visualização de notas do aluno",
                // " (5) Relatorios",
                " (0) Sair",
            };
            PrintMenu(text, textLenght);
        }
        private static void PrintMenu(IEnumerable<string> text, int textLenght)
        {
            PrintLineMenuLenght(textLenght);
            foreach (var line in text)
                WriteText(textLenght, $"{line}");
            PrintLineMenuLenght(textLenght);
        }
        private static void PrintLineMenuLenght(int textLenght)
        {
            var text = $"{"+".PadRight(textLenght - 3, '=')}+";
            Console.WriteLine(text);
        }

        private static void WriteText(int textLenght, string text)
        {
            var newText = $"{$"| {text}".PadRight(textLenght - 4, ' ')} |";
            Console.WriteLine(newText);
        }
    }
}