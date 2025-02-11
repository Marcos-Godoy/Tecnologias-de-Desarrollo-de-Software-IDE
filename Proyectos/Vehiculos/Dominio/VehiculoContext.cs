using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dominio
{
    internal class VehiculoContext : DbContext
    {
        internal DbSet<Vehiculo> Vehiculos { get; set; }
        internal DbSet<TipoPropiedad> TiposPropiedades { get; set; }
        internal VehiculoContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=DESKTOP-32F2S83\\SQLEXPRESS; Database=ParcialAutos; Integrated Security=True; trustServerCertificate=true");
    }
}
