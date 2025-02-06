using Microsoft.EntityFrameworkCore;
using Jaca.Entidades;

namespace Jaca.Datos
{

    public class InmobiliariaContext : DbContext
    {
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<TipoPropiedad> TiposPropiedades { get; set; }

        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propiedad>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Propiedad>()
                .HasOne(p => p.TipoPropiedad)
                .WithMany()
                .HasForeignKey(p => p.IdTipoPropiedad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TipoPropiedad>()
                .HasKey(tp => tp.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-32F2S83\SQLEXPRESS;Initial Catalog=Parcial;Integrated Security=True;TrustServerCertificate=True");

        public InmobiliariaContext()
        {
            Database.EnsureCreated();
        }
    }
}
