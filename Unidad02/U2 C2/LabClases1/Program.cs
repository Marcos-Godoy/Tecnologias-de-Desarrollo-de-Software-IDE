using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace LabClases1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A claseA = new A();
            B claseB = new B();

            claseA.MostrarNombre();
            claseA.M1();
            claseA.M2();
            claseA.M3();

            claseB.MostrarNombre();
            claseB.M1();
            claseB.M2();
            claseB.M3();
        }
    }
}
