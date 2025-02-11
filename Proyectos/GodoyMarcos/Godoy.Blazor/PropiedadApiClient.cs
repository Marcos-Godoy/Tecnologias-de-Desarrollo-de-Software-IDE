using Godoy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Godoy.Blazor
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
            Propiedad entidad = null;
            HttpResponseMessage response = await client.GetAsync("entidades/" + id);
            if (response.IsSuccessStatusCode)
            {
                entidad = await response.Content.ReadAsAsync<Propiedad>();
            }
            return entidad;
        }

        public static async Task<IEnumerable<Propiedad>> GetAllAsync()
        {
            IEnumerable<Propiedad> entidades = null;
            HttpResponseMessage response = await client.GetAsync("entidades");
            if (response.IsSuccessStatusCode)
            {
                entidades = await response.Content.ReadAsAsync<IEnumerable<Propiedad>>();
            }
            return entidades;
        }

        public static async Task AddAsync(Propiedad entidad)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("entidades", entidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("entidades/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Propiedad entidad)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("entidades", entidad);
            response.EnsureSuccessStatusCode();
        }
    }
}
