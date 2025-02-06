using Ejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
