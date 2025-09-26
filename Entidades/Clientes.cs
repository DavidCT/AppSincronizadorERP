using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSincronizadorERP.Entidades
{
    [Table("tbMaestroCliente")]
    public class Clientes
    {
        [Key]
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El ID del cliente no puede tener más de 50 caracteres.")] 
        public required string IDCliente { get; set; }

        public required string DescCliente { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public string? Poblacion { get; set; }
    }
}
