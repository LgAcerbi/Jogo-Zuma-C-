using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaDENO
{
    static class ConsoleUtils           //Classe utilizada para mudança de cores no console
    {

        public static void ChangeConsoleColor(String color = null)
        {
            switch (color)
            {
                case "Azul":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Amarelo":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Vermelho":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Verde":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
