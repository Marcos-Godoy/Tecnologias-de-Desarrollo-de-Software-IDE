using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public int TipoPropiedadId { get; set; }

        public string TipoPropiedadDescripcion { get; set; }
        public int CantidadPuertas { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
