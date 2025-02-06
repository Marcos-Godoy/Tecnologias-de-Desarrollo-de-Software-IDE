using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godoy.Domain
{
    public class Propiedad
    {
        public int Id { get; set; }
        //public string TipoPropiedad { get; set; }
        public int IdTipoPropiedad { get; set; } // Agrego esto para AD
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int M2 { get; set; }
        public int CantidadHabitaciones { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}
