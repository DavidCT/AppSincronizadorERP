using AppSincronizadorERP.Contexto;
using AppSincronizadorERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppSincronizadorERP.Modelos;

namespace AppSincronizadorERP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaVentaCabeceraController : Controller
    {
        private readonly AppDbContext _context;

        public FacturaVentaCabeceraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaVentaCabecera>>> GetFacturasVenta()
        {
            return await _context.FacturaVentaCabecera.ToListAsync();
        }

        [HttpGet("ByDate")]
        public async Task<ActionResult<IEnumerable<FacturaVentaCabecera>>> GetFacturasByDate()
        {
            var fechaLimite = new DateTime(2024, 1, 1);

            var facturas = await _context.FacturaVentaCabecera
                .Where(f => f.FechaFactura >= fechaLimite)
                .OrderByDescending(f => f.NFactura)
                .ToListAsync();

            return facturas;
        }

        [HttpPost("ByDate")]
        public async Task<ActionResult<IEnumerable<FacturaVentaCabecera>>> GetFacturasByDate([FromBody] FechaRequest request)
        {
            var facturas = await _context.FacturaVentaCabecera
                .Where(f => f.FechaFactura >= request.Fecha)
                .OrderByDescending(f => f.NFactura)
                .ToListAsync();

            return facturas;
        }
    }
}
