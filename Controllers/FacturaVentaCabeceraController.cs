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
        public async Task<ActionResult<IEnumerable<FacturaVentaCabecera>>> ObtenerFacturasVenta()
        {
            return await _context.FacturaVentaCabecera.ToListAsync();
        }

        [HttpPost("PorFecha")]
        public async Task<ActionResult<IEnumerable<FacturaVentaCabecera>>> ObtenerFacturasVentaPorCliente([FromBody] FechaRequest request)
        {
            var facturas = await _context.FacturaVentaCabecera
                .Where(f => f.FechaFactura >= request.Fecha)
                .OrderByDescending(f => f.NFactura)
                .ToListAsync();

            return facturas;
        }
    }
}
