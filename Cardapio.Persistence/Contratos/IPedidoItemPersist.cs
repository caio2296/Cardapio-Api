using Cardapio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence.Contratos
{
    public interface IPedidoItemPersist
    {
        Task<PedidoItem[]> GetAllPedidoItensAsync();
        Task<PedidoItem> GetPedidoByIdAsync(int pedidoItemId);
    }
}
