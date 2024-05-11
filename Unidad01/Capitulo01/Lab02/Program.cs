using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valor1 = "Este es el valor 1";
            int valor2 = 5;
            string valor3 = valor1;

            Console.WriteLine(valor1);
            Console.WriteLine(valor2);
            Console.WriteLine(valor3);

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            /*
             Acceder a la carpeta (con el Explorador de Windows) donde fue creado el proyecto y la solución.
Observar la estructura en la que la solución se guarda, y acceder hasta la carpeta Bin. En esta encontrara otra llamada Debug, dentro de la carpeta Debug, se deposita la aplicación compilada. Ejecutar Lab02.exe.
*/
        }
    }
}
