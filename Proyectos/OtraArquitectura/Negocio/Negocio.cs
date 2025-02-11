using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class Negocio
    {
        public async static Task<IEnumerable<Alumno>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7012/api/Controlador/");
            var data = JsonConvert.DeserializeObject<List<Alumno>>(response);
            return data;
        }

        public async static Task<Alumno> Get(string DNI)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7012/api/Controlador/" + DNI);
            var data = JsonConvert.DeserializeObject<Alumno>(response);
            return data;
        }

        public async static Task<Boolean> Delete(Alumno entidad)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync("https://localhost:7012/api/Controlador/" + entidad.DNI);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Add(Alumno entidad)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7012/api/Controlador/", entidad);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(Alumno entidad)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync("https://localhost:7012/api/Controlador/" + entidad.DNI, entidad);
            return response.IsSuccessStatusCode;
        }
    }
}
