using AppSincronizadorERP.Contexto;
using AppSincronizadorERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppSincronizadorERP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : Controller
    {
        private readonly AppDbContext _context;

        public ArticulosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpGet("PorFechaAlta/{FechaAlta}")]
        public async Task<ActionResult<IEnumerable<Articulos>>> ObtenerArticuloPorFecha(DateTime FechaAlta)
        {
            try
            {
                if (FechaAlta == DateTime.MinValue) { return BadRequest("La fecha no es válida."); }

                var articulos = await _context.Articulos
                   .Where(f => f.FechaAlta >= FechaAlta)
                   .OrderByDescending(f => f.FechaAlta)
                   .ToListAsync();

                return Ok(articulos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
