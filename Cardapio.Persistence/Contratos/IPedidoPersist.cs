using Cardapio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence.Contratos
{
    public interface IPedidoPersist
    {
        Task<Pedido[]> GetAllPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int pedidoId);
    }
}
