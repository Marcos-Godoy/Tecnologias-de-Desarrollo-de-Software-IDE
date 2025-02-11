using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioService
    {
        public bool ValidarUsuario(string nombre, string contrasena)
        {
            using (var context = new MyDbContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.Nombre == nombre && u.Contrasena == contrasena);
                return usuario != null;
            }
        }
    }
}
