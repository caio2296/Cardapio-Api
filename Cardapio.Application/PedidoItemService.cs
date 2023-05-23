using AutoMapper;
using Cardapio.Application.Contratos;
using Cardapio.Application.Dtos;
using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application
{
    public class PedidoItemService : IPedidoItemService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPedidoItemPersist _pedidoItemPersist;
        private readonly IMapper _mapper;



        public PedidoItemService(
            IGeralPersist geralPersist,
            IPedidoItemPersist pedidoItemPersist,
             IMapper mapper)
        {
            _geralPersist = geralPersist;
            _pedidoItemPersist = pedidoItemPersist;
            _mapper = mapper;

        }

       
        public async Task<PedidoItemDto> AddPedidoItem(PedidoItemDto model)
        {
            try
            {
                var pedidoItem = _mapper.Map<PedidoItem>(model);
                _geralPersist.Add(pedidoItem);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoItemPersist.GetPedidoByIdAsync(pedidoItem.Id);
                    return _mapper.Map<PedidoItemDto>(pedidoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePedidoItem(int pedidoItemId)
        {
            try
            {
                var pedidoItem = await _pedidoItemPersist.GetPedidoByIdAsync(pedidoItemId);
                if (pedidoItem == null) throw new Exception("Erro ao excluir o item do pedido. Item não encontrado!");

                _geralPersist.Delete(pedidoItem);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoItemDto[]> GetAllPedidosItensAsync()
        {
            try
            {
                var pedidosItens = await _pedidoItemPersist.GetAllPedidoItensAsync();
                if (pedidosItens == null) return null;

                var resultado = _mapper.Map<PedidoItemDto[]>(pedidosItens);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoItemDto> GetPedidoItemByIdAsync(int pedidoItemId)
        {
            try
            {
                var pedidoItem = await _pedidoItemPersist.GetPedidoByIdAsync(pedidoItemId);
                if (pedidoItem == null) return null;

                var resultado = _mapper.Map<PedidoItemDto>(pedidoItem);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoItemDto> UpdatePedidoItem(int pedidoItemId, PedidoItemDto model)
        {
            try
            {
                var pedidoItem = await _pedidoItemPersist.GetPedidoByIdAsync(pedidoItemId);
                if (pedidoItem == null) return null;

                model.Id = pedidoItem.Id;

                _mapper.Map(model, pedidoItem);
                _geralPersist.Update(pedidoItem);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoItemPersist.GetPedidoByIdAsync(pedidoItem.Id);
                    return _mapper.Map<PedidoItemDto>(pedidoRetorno);
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
