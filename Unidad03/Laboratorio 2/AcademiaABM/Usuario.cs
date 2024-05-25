using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaABM
{
    internal class Usuario1
    {
        private int id;
        private string nombre, apellido, usuario, email;
        private bool habilitado;
        
        public Usuario1(int i, string nom, string ape, string usu, string em, bool hab)
        {
            this.id = i;
            this.nombre = nom;
            this.apellido = ape;
            this.usuario = usu;
            this.email = em;
            this.habilitado = hab;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string Usuario { get { return usuario; } set { usuario = value; } }
        public string EMail { get { return email; } set { email = value; } }
        public bool Habilitado { get { return habilitado; } set { habilitado = value; } }
    }
}
