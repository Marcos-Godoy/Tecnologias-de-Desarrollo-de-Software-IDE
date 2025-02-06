using Godoy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

// Se podria armar una clase conexion instanciando un cliente, y ponerlo en un proyecto Negocio junto al PropiedadNegocio
// que reemplazaria este archivo, usandolo en Web y Escritorio.

namespace Godoy.Presentacion
{
    public class PropiedadApiClient
    {
        private static HttpClient client = new HttpClient();

        static PropiedadApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7252/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Propiedad> GetAsync(int id)
        {
            Propiedad entity = null;
            HttpResponseMessage response = await client.GetAsync("propiedades/" + id);
            if (response.IsSuccessStatusCode)
            {
                entity = await response.Content.ReadAsAsync<Propiedad>();
            }
            return entity;
        }

        public static async Task<IEnumerable<Propiedad>> GetAllAsync()
        {
            IEnumerable<Propiedad> entities = null;
            HttpResponseMessage response = await client.GetAsync("propiedades");
            if (response.IsSuccessStatusCode)
            {
                entities = await response.Content.ReadAsAsync<IEnumerable<Propiedad>>();
            }
            return entities;
        }

        public static async Task AddAsync(Propiedad entity)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("propiedades", entity);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("propiedades/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Propiedad entity)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("propiedades", entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
