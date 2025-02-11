using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VehiculoValidation
    {
        public static bool IsValid(Vehiculo vehiculo)
        {

            if (vehiculo == null)
            {
                throw new Exception("Los datos del vehiculo son requeridos");
            }
            if (vehiculo.CantidadPuertas <= 0 || vehiculo.CantidadPuertas > 10)
            {
                throw new Exception("El campo Cantidad de puertas debe ser mayor a 0 y menor que 10.");
            }
            if (String.IsNullOrEmpty(vehiculo.Patente))
            {
                throw new Exception("El campo Patente es requerido.");
            }
            if (vehiculo.Modelo.Length > 50)
            {
                throw new Exception("El campo Modelo tiene que tener menos de 50 caracteres.");
            }

            // Si llega hasta acá es porque no falló ninguna validación.
            return true;

        }
    }
}
