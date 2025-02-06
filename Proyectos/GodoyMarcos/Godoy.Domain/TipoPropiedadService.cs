using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godoy.Domain
{
    public class TipoPropiedadService
    {
        public IEnumerable<TipoPropiedad> GetAll()
        {
            using var context = new PropiedadContext();
            return context.TiposPropiedades.ToList();
        }
    }
}
