using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoPropiedadService
    {
        public IEnumerable<TipoPropiedad> GetAll()
        {
            using var context = new VehiculoContext();
            return context.TiposPropiedades.ToList();
        }
    }
}
