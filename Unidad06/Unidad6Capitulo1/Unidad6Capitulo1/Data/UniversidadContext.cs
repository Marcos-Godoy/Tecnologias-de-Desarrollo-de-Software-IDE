using Microsoft.EntityFrameworkCore;
using Unidad6Capitulo1.Models;

namespace Unidad6Capitulo1.Data
{
    public class UniversidadContext : DbContext
    {
        // defino la coleccion de alumnos
        public DbSet<Alumno> Alumnos { get; set; }

        // constructor de la clase...
        public UniversidadContext()
        {
            // Asegura que la base de datos se cree si no existe
            this.Database.EnsureCreated();
        }

        // configuro la bd
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura SQL Server como proveedor de base de datos
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Universidad;Integrated Security=true");

            // Configurar el registro de las consultas SQL en la consola
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
