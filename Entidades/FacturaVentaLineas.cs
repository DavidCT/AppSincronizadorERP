using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbFacturaVentaLinea")]
    public class FacturaVentaLineas
    {
        [Key] public required int IDLineaFactura { get; set; }
        public required int IDFactura { get; set; }
        public required string IDArticulo { get; set; }
        public string? DescArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public DateTime? FechaCreacionAudi { get; set; }
    }
}
