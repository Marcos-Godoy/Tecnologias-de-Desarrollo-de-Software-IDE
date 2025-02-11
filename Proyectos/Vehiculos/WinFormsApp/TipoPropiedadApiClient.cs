using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace WinFormsApp
{
    public class TipoPropiedadApiClient
    {
        private static HttpClient client = new HttpClient();
        static TipoPropiedadApiClient()
        {
            // Esta URL se podría pasar a un setting
            client.BaseAddress = new Uri("https://localhost:7010/"); // cambiarrr
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<TipoPropiedad>> GetAllAsync()
        {
            IEnumerable<TipoPropiedad> entities = null;
            HttpResponseMessage response = await client.GetAsync("tipos-propiedades");
            if (response.IsSuccessStatusCode)
            {
                entities = await response.Content.ReadAsAsync<IEnumerable<TipoPropiedad>>();
            }
            return entities;
        }
    }
}
