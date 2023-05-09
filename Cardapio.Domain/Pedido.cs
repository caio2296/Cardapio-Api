using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Domain
{
    public class Pedido
    {
        public int Id { get; set; }

        public int Mesa { get; set; }

        public ICollection<PedidoItem> Itens { get; set; } =
         new List<PedidoItem>();
    }
}
