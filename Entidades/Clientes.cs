using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbMaestroCliente")]
    public class Clientes
    {
        [Key] public required string IDCliente { get; set; }
        public required string DescCliente { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
    }
}
