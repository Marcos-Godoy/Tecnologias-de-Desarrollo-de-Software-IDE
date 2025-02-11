using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godoy.Domain
{
    public class Validaciones
    {
        public static bool IsValid(Propiedad entidad)
        {

            if (entidad == null)
            {
                throw new Exception("Los datos son requeridos");
            }
            if (entidad.CantidadHabitaciones <= 0 || entidad.CantidadHabitaciones > 10)
            {
                throw new Exception("El campo Cantidad de Habitaciones debe ser mayor a 0 y menor que 10.");
            }
            if (String.IsNullOrEmpty(entidad.Descripcion))
            {
                throw new Exception("El campo Descripcion es requerido.");
            }
            if (entidad.Titulo.Length > 50)
            {
                throw new Exception("El campo Titulo tiene que tener menos de 50 caracteres.");
            }

            // Si llega hasta acá es porque no falló ninguna validación.
            return true;

        }
    }
}
