using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Boleto
    {
        [Key]
        public int idBoleto { get; set; }

        public int idCliente { get; set; }
    }
}
