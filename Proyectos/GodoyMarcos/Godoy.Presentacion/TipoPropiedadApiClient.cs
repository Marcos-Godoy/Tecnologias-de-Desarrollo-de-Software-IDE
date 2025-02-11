using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Godoy.Domain;

namespace Godoy.Presentacion
{
    public class TipoPropiedadApiClient
    {
        private static HttpClient client = new HttpClient();
        static TipoPropiedadApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7252/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<TipoPropiedad>> GetAllAsync()
        {
            IEnumerable<TipoPropiedad> entidades = null;
            HttpResponseMessage response = await client.GetAsync("tipos");
            if (response.IsSuccessStatusCode)
            {
                entidades = await response.Content.ReadAsAsync<IEnumerable<TipoPropiedad>>();
            }
            return entidades;
        }
    }
}
