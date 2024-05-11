using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteracion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] arrayStrings = new string[cantIteraciones];

            for (int i = 0; i < cantIteraciones; i++)
            {
                Console.WriteLine($"Ingrese el elemento {i + 1}: ");
                arrayStrings[i] = Console.ReadLine();
            }
            Console.WriteLine("Elementos ingresados en orden inverso:");
            for (int i = cantIteraciones - 1; i >= 0; i--)
            {
                Console.WriteLine(arrayStrings[i]);
            }
        }
    }
}
