using System.ComponentModel.DataAnnotations.Schema;

namespace PC2.Models
{
    [Table("t_cuenta")]
    public class Cuenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? NombreTitular { get; set; }
        public string? TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public string? Email { get; set; }
    }
}