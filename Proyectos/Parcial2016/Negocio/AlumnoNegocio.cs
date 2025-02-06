using Datos;
using Entidades;

namespace Negocio
{
    public class AlumnoNegocio
    {
        public List<Alumno> RecuperarTodos()
        {
            Controlador c = new Controlador();
            return c.RecuperarTodos();
        }
    }
}
