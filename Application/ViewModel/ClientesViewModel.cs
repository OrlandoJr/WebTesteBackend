using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class ClientesViewModel
    {
        public ClientesViewModel()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
    
}
