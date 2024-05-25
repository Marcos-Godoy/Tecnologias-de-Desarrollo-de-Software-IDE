using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal class B : A
    {
        public B() : base("Instancia de B")
        {
        }

        public void M3()
        {
            Console.WriteLine("Se invocó el método hijo");
        }
    }
}
