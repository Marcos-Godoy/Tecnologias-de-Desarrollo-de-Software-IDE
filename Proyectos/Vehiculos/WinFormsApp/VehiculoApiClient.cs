using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Dominio;


namespace WinFormsApp
{
    public class VehiculoApiClient
    {
        private static HttpClient client = new HttpClient();
        static VehiculoApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7010/"); // cambiar
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<Vehiculo> GetAsync(int id)
        {
            Vehiculo vehiculo = null;
            HttpResponseMessage response = await client.GetAsync("vehiculos/" + id);
            if (response.IsSuccessStatusCode)
            {
                vehiculo = await response.Content.ReadAsAsync<Vehiculo>();
            }
            return vehiculo;
        }

        // Cambiar por vehiculo Dto
        public static async Task<IEnumerable<VehiculoDto>> GetAllAsync()
        {
            IEnumerable<VehiculoDto> entities = null;
            HttpResponseMessage response = await client.GetAsync("vehiculos");

            if (response.IsSuccessStatusCode)
            {
                entities = await response.Content.ReadAsAsync<IEnumerable<VehiculoDto>>();
            }
            return entities;
        }

        public static async Task AddAsync(Vehiculo vehiculo)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("vehiculos", vehiculo);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("vehiculos/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Vehiculo vehiculo)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("vehiculos", vehiculo);
            response.EnsureSuccessStatusCode();
        }
    }
}
