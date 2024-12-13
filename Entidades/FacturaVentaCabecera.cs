using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbFacturaVentaCabecera")]
    public class FacturaVentaCabecera
    {
        [Key] public required int IDFactura { get; set; }

        [MaxLength(25)]
        public required string NFactura { get; set; }

        public required DateTime FechaFactura { get; set; }
        public required string IDCliente { get; set; }
        public string? RazonSocial { get; set; }
        public string? CifCliente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseImponible { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ImpIVA { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ImpTotal { get; set; }
    }
}
