using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
