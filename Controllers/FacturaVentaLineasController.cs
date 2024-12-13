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
            try
            {
                var facturas = await _context.FacturaVentaLineas.ToListAsync();
                return Ok(facturas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpGet("PorFechaCreacion/{fechaLimite}")] // Pasar la fecha como parámetro
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Documentar posible Bad Request
        public async Task<ActionResult<IEnumerable<FacturaVentaLineas>>> GetFacturasByDate(DateTime fechaLimite)
        {
            if (fechaLimite == DateTime.MinValue) // Validar la fecha
            {
                return BadRequest("La fecha límite no es válida.");
            }

            try
            {
                var facturas = await _context.FacturaVentaLineas
                    .Where(f => f.FechaCreacionAudi >= fechaLimite)
                    .OrderByDescending(f => f.IDArticulo)
                    .ToListAsync();

                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
