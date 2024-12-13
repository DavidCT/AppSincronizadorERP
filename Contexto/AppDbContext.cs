using AppSincronizadorERP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppSincronizadorERP.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaVentaCabecera> FacturaVentaCabecera { get; set; }
        public DbSet<FacturaVentaLineas> FacturaVentaLineas { get; set; }
    }
}
