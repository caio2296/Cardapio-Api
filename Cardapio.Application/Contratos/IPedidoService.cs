using Cardapio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Contratos
{
    public interface IPedidoService
    {
        Task<PedidoDto> AddPedido(PedidoDto model);
        Task<PedidoDto> UpdatePedido(int pedidoId, PedidoDto model);
        Task<bool> DeletePedido(int produtoId);
        Task<PedidoDto[]> GetAllPedidosAsync();
        Task<PedidoDto> GetPedidoByIdAsync(int edidoId);
    }
}
