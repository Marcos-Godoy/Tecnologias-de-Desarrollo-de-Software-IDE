using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputTexto = Console.ReadLine();
            if(inputTexto != "")
            {
                Console.WriteLine("Se ingreso texto");
            } else
            {
                Console.WriteLine("No se ingreso texto");
            }

            ConsoleKeyInfo opcion = Console.ReadKey();
            Console.WriteLine("Ingrese una opcion...\n 1) Mayuscula\n 2) Minuscula\n 3) Longitud");
            /*
            // menu de opciones con if anidados
            
            if (opcion.Key == ConsoleKey.D1)
            {
                Console.WriteLine(inputTexto.ToUpper());
            } else if(opcion.Key == ConsoleKey.D2)
            {
                Console.WriteLine(inputTexto.ToLower());
            } else if( opcion.Key == ConsoleKey.D3)
            {
                Console.WriteLine(inputTexto.Length);
            } else
            {
                Console.WriteLine("Ingreso incorrecto...");
            }
            */

            // menu de opciones con case
            switch(opcion.Key) {
                case ConsoleKey.D1:
                    Console.WriteLine(inputTexto.ToUpper());
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine(inputTexto.ToLower());
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine(inputTexto.Length);
                    break;
                default:
                    Console.WriteLine("Ingreso incorrecto...");
                    break;
            }
        }
    }
}
