using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbMaestroArticulo")]
    public class Articulos
    {
        [Key] public required string IDArticulo { get; set; }
        public required string DescArticulo { get; set; }
        public DateTime? FechaAlta { get; set; }
    }
}
