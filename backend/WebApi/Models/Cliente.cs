using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Cliente
    {

      
        [Key]
        public int IdCliente { get; set; }

      
        public string Nombres { get; set; }

        
        public string Apellidos { get; set;}

       
        public string Email { get; set;}

        
        public string Clave { get; set;}

  
    }
}
