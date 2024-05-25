namespace Clases
{
    public class Persona
    {
        private int edad, dni;
        private string nombre, apellido;

        public Persona(int ed, int dn, string nom, string ape)
        {
            nombre = nom;
            apellido = ape;
            edad = ed;
            dni = dn;
            Console.WriteLine("Se creo instancia de persona");
        }

        ~Persona()
        {
            Console.WriteLine("Se destruyó la instancia de Persona");
            Console.ReadKey();
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Nombre
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

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string GetFullName()
        {
            return nombre + "" + apellido;
        }

        public int GetAge()
        {
            return edad;
        }
    }
}
