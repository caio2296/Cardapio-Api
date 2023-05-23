using AutoMapper;
using Cardapio.Application.Contratos;
using Cardapio.Application.Dtos;
using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace Cardapio.Application
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoPersist _pedidoPersist;
        private readonly IMapper _mapper;



        public PedidoService(
            IPedidoPersist pedidoPersist,
             IMapper mapper)
        {
            
            _pedidoPersist = pedidoPersist;
            _mapper = mapper;

        }


        public async Task<PedidoDto> AddPedido(PedidoDto model)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(model);
                _pedidoPersist.Add(pedido);

                if (await _pedidoPersist.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoPersist.GetPedidoByIdAsync(pedido.Id);
                    return _mapper.Map<PedidoDto>(pedidoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePedido(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(pedidoId);
                if (pedido == null) throw new Exception("Erro ao excluir pedido. Pedido não encontrado!");

                _pedidoPersist.Delete(pedido);

                return await _pedidoPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto[]> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoPersist.GetAllPedidosAsync();
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDto[]>(pedidos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> GetPedidoByIdAsync(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(pedidoId);
                if (pedido == null) return null;

                var resultado = _mapper.Map<PedidoDto>(pedido);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> UpdatePedido(int pedidoId, PedidoDto model)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(pedidoId);
                if (pedido == null) return null;

                model.Id = pedido.Id;

                _mapper.Map(model, pedido);
                _pedidoPersist.Update(pedido);

                if (await _pedidoPersist.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoPersist.GetPedidoByIdAsync(pedido.Id);
                    return _mapper.Map<PedidoDto>(pedidoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
