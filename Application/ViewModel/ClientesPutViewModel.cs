using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class ClientesPutViewModel
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
