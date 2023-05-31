﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get;}

    }
}
