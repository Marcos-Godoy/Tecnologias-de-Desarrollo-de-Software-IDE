using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Newtonsoft.Json;

namespace Negocio
{
    public class AlumnoNegocio
    {
        public async static Task<IEnumerable<Alumno>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7011/api/Alumno/");
            var data = JsonConvert.DeserializeObject<List<Alumno>> (response);
            return data;
        }
    }
}
