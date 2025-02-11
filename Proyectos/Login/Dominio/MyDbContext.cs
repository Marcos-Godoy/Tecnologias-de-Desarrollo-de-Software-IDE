using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dominio
{
    public class MyDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }
        // podria cambiar el string de conexion. @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ClienteDb;Integrated Security=True;TrustServerCertificate=True"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-32F2S83\SQLEXPRESS;Initial Catalog=Login2;Integrated Security=True;TrustServerCertificate=True");
    }


}
