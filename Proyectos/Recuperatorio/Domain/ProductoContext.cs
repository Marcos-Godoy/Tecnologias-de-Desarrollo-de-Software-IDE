using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ProductoContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        //public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }
        
        public ProductoContext()
        {
            this.Database.EnsureCreated();
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            //optionsBuilder.UseSqlServer("Server=DESKTOP-32F2S83\\SQLEXPRESS; Database=PCProductos; Integrated Security=True; trustServerCertificate=true");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=PCProductos;Integrated Security=True;trustServerCertificate=True");
    }
}
