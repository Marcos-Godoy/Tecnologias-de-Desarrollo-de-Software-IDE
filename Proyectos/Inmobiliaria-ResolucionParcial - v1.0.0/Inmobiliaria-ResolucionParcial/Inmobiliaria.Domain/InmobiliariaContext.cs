﻿using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Domain
{
    internal class InmobiliariaContext : DbContext
    {
        internal DbSet<Propiedad> Propiedades { get; set;}

        internal DbSet<TipoPropiedad> TiposPropiedades { get; set; }

        internal InmobiliariaContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=DESKTOP-32F2S83\\SQLEXPRESS; Database=InmobiliariaDb-v1; Integrated Security=True; trustServerCertificate=true");
    }
}
