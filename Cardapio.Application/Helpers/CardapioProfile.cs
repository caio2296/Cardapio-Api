using AutoMapper;
using Cardapio.Application.Dtos;
using Cardapio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Helpers
{
    public class CardapioProfile:Profile
    {
        public CardapioProfile()
        {
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemDto>().ReverseMap();
        }

    }
}
