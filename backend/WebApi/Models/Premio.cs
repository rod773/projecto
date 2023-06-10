using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Premio
    {
        [Key]
        public int idPremip { get; set; }

        public string nombre { get; set; }

        public int idBoleto { get; set;}
    }
}
