using System.Net.Http.Headers;

namespace Negocio
{
    public sealed class Conexion
    {
        private Conexion() { }
        private static Conexion? instacia;
        private HttpClient _Cliente = new HttpClient();

        public HttpClient Cliente
        {
            get { return _Cliente; }
        }

        public static Conexion Instancia
        {
            get
            {
                if (instacia == null)
                {
                    instacia = new Conexion();
                    instacia._Cliente.DefaultRequestHeaders.Accept.Clear();
                    instacia._Cliente.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }
                return instacia;
            }
        }

    }
}
