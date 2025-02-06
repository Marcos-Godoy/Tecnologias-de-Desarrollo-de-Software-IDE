using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    public class UniversidadContext : DbContext
    {
        // Definir la propiedad DbSet para la colección de alumnos
        public DbSet<Alumno> Alumnos { get; set; }

        // Constructor que asegura la creación de la base de datos si no existe
        public UniversidadContext()
        {
            this.Database.EnsureCreated();
        }


        // Sobrescribir el método OnConfiguring para configurar la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar el uso de SQL Server y la cadena de conexión
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Universidad;Integrated Security=true");

            // Opción para mostrar el código SQL generado en la consola
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
