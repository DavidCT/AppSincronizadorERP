using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbFacturaVentaCabecera")]
    public class FacturaVentaCabecera
    {
        [Key] public required int IDFactura {  get; set; }
        public required string NFactura { get; set; }
        public required DateTime FechaFactura { get; set; }
        public required string IDCliente { get; set; }
        public string ? RazonSocial { get; set; }
        public string ? CifCliente { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal ImpIVA { get; set; }
        public decimal ImpTotal { get; set; }
    }
}
