using AppSincronizadorERP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppSincronizadorERP.Contexto
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaVentaCabecera> FacturaVentaCabecera { get; set; }
        public DbSet<FacturaVentaLineas> FacturaVentaLineas { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
    }
}
