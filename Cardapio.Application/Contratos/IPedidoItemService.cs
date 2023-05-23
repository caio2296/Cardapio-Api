using Cardapio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Contratos
{
    public interface IPedidoItemService
    {
        Task<PedidoItemDto> AddPedidoItem(PedidoItemDto model);
        Task<PedidoItemDto> UpdatePedidoItem(int pedidoItemId, PedidoItemDto model);
        Task<bool> DeletePedidoItem(int pedidoItemId);
        Task<PedidoItemDto[]> GetAllPedidosItensAsync();
        Task<PedidoItemDto> GetPedidoItemByIdAsync(int pedidoItemId);
    }
}
