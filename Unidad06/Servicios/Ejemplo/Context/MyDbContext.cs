using Microsoft.EntityFrameworkCore;
using Ejemplo.Models;

namespace Ejemplo.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options ) : base(options) { }

        //public DbSet<Alumnos> Productos { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; } // tuve q cambiar esto porque estaba mal el ppt

    }
}
