using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class A
    {
        string nombre;

        public string NombreInstancia
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public A()
        {
            nombre = "Instancia sin nombre";
        }

        public A(string nombreAsignado)
        {
            this.nombre = nombreAsignado;
        }

        public void MostrarNombre()
        {
            Console.WriteLine("El nombre de la instancia es: " + nombre + ".");
        }

        public void M1()
        {
            Console.WriteLine("Se ha invocado el método M1");
        }

        public void M2()
        {
            Console.WriteLine("Se ha invocado el método M2");
        }

        public void M3()
        {
            Console.WriteLine("Se ha invocado el método M3");
        }
    }
}

