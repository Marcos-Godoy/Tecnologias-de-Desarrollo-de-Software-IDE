using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Presentacion
{
    public class ProductoApiClient
    {
        private static HttpClient client = new HttpClient();

        static ProductoApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7165/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<Producto>> GetAllAsync()
        {
            IEnumerable<Producto> entities = null;
            HttpResponseMessage response = await client.GetAsync("productos");
            if(response.IsSuccessStatusCode)
            {
                entities = await response.Content.ReadAsAsync<IEnumerable<Producto>>();
            }
            return entities;
        }

        public static async Task AddAsync(Producto producto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("productos", producto);
            response.EnsureSuccessStatusCode();
        }

        public static async Task<Producto> GetAsync(int id)
        {
            Producto entity = null;
            HttpResponseMessage response = await client.GetAsync("productos/" + id);
            if (response.IsSuccessStatusCode)
            {
                entity = await response.Content.ReadAsAsync<Producto>();
            }
            return entity;
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("productos/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Producto entity)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("productos", entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
