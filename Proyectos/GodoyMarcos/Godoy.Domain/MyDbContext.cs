using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Godoy.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Propiedad> Propiedades {  get; set; }

        public DbSet<TipoPropiedad> TiposPropiedades { get; set; }
        public MyDbContext() 
        {
            this.Database.EnsureCreated();
        }
        // podria cambiar el string de conexion. @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ClienteDb;Integrated Security=True;TrustServerCertificate=True"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-32F2S83\SQLEXPRESS;Initial Catalog=Parcial;Integrated Security=True;TrustServerCertificate=True");
    }
}
