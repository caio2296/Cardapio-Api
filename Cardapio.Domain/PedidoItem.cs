﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Domain
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal ValorProduto { get; set; }
        public Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int? PedidoId { get; set; }
    }
}
