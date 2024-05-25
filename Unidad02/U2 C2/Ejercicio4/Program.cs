using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Personas
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona(91, 123, "Marcos", "Godoy");
            Console.WriteLine(persona1.GetFullName());
            Console.WriteLine(persona1.GetAge());
            Console.WriteLine(persona1.Dni);
            Console.ReadKey();
        }
    }
}