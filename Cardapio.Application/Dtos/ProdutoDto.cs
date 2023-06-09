﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
          StringLength(25, MinimumLength = 3, ErrorMessage = "Insira de 2 a 30 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         StringLength(50, MinimumLength = 3, ErrorMessage = "Insira de 2 a 30 caracteres.")]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }

        public string ImagemUrl { get; set; } = string.Empty;
    }
}
