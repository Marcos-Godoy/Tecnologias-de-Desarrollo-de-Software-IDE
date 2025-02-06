using System.Linq.Expressions;

namespace Entidades
{
    public class Alumno
    {
        private string apellidoNombre, dni, email;
        private int edad, id;
        private DateTime fechaNacimiento;
        private decimal notaPromedio;


        public Alumno(string apellidoNombre, string dni, string email, DateTime fechaNacimiento, decimal notaPromedio)
        {
            this.Id = id;
            this.apellidoNombre = apellidoNombre;
            this.dni = dni;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.notaPromedio = notaPromedio;
        }

        public Alumno()
        {
        }

        public int Id { get { return id; } set { id = value; } }
        public string ApellidoNombre
        { get { return apellidoNombre; } set { apellidoNombre = value; } }
        public int Edad 
        { get 
            { 
                return edad = DateTime.Today.Year - fechaNacimiento.Year;
            } 
        }

        public string Dni 
        { get { return dni; } set { dni = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento = value; } }

        public decimal NotaPromedio { get { return notaPromedio; } set { notaPromedio = value; } }


    }
}
