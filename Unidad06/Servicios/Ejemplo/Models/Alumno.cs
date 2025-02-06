using System.ComponentModel.DataAnnotations;

namespace Ejemplo.Models
{
    public class Alumno
    {
        [Key]
        public String DNI { get; set; }
        public String ApellidoNombre { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal NotaPromedio { get; set; }
    }
}
