using AppSincronizadorERP.Contexto;
using AppSincronizadorERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppSincronizadorERP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaVentaLineasController : Controller
    {
        private readonly AppDbContext _context;

        public FacturaVentaLineasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaVentaLineas>>> GetFacturasVentaLinea()
        {
            return await _context.FacturaVentaLineas.ToListAsync();
        }

        [HttpGet("PorFechaCreacion")]
        public async Task<ActionResult<IEnumerable<FacturaVentaLineas>>> GetFacturasByDate()
        {
            var fechaLimite = new DateTime(2024, 1, 1);

            var facturas = await _context.FacturaVentaLineas
                .Where(f => f.FechaCreacionAudi >= fechaLimite)
                .OrderByDescending(f => f.IDArticulo)
                .ToListAsync();

            return facturas;
        }
    }
}
