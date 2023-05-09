using Cardapio.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        [Required]
        public int Mesa { get; set; }
        public ICollection<PedidoItem> Itens { get; set; } =
         new List<PedidoItem>();
    }
}
