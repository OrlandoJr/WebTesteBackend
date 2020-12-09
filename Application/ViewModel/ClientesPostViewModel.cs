using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class ClientesPostViewModel
    {
        public ClientesPostViewModel()
        {
        }

        [MaxLength(100)]
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
