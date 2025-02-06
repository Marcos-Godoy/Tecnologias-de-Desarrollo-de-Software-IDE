﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    
    public class AlumnoNegocio
    {

        public async static Task<IEnumerable<Alumno>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync("https://localhost:7129/api/Alumno/");
            var data = JsonConvert.DeserializeObject<List<Alumno>>(response);
            return data;
        }

        public async static Task<Boolean> Delete(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync("https://localhost:7129/api/Alumno/" + alumno.DNI);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Add(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync("https://localhost:7129/api/Alumno/", alumno);
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(Alumno alumno)
        {
            var response = await Conexion.Instancia.Cliente.PutAsJsonAsync("https://localhost:7129/api/Alumno/" + alumno.DNI, alumno);
            return response.IsSuccessStatusCode;
        }
    }
}
