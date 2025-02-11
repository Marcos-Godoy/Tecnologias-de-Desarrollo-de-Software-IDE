using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class UsuarioApiClient
    {
        private static HttpClient client = new HttpClient();

        static UsuarioApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7158/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<bool> ValidarAsync(string nombre, string contraseña)
        {
            var usuarioLoginDto = new { username = nombre, password = contraseña }; // Los nombres deben coincidir con los del endpoint
            HttpResponseMessage response = await client.PostAsJsonAsync("login", usuarioLoginDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<bool>();
            }

            return false;
        }

    }
}
