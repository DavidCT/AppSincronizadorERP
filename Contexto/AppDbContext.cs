using AppSincronizadorERP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppSincronizadorERP.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FacturaVentaCabecera>(entity =>
            {
                entity.Property(e => e.BaseImponible).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImpIVA).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImpTotal).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<FacturaVentaLineas>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Importe).HasColumnType("decimal(18,2)");
            });
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaVentaCabecera> FacturaVentaCabecera { get; set; }
        public DbSet<FacturaVentaLineas> FacturaVentaLineas { get; set; }
    }
}
