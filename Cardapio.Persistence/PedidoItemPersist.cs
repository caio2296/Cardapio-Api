using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence
{
    public class PedidoItemPersist : IPedidoItemPersist
    {
        public Task<PedidoItem[]> GetAllPedidoItensAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> GetPedidoByIdAsync(int pedidoItemId)
        {
            throw new NotImplementedException();
        }
    }
}
