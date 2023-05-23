using Cardapio.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Application.Dtos
{
    public class PedidoItemDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            Range(1,99)]
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal ValorProduto { get; set; }
        public Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int? PedidoId { get; set; }
    }
}
