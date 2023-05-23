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
        public int  Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         Range(0,100)]
        public int Mesa { get; set; }
        public int IdPedidoItem { get; set; }
        public ICollection<PedidoItem> ItemPedidos { get; set; } =
         new List<PedidoItem>();
    }
}
