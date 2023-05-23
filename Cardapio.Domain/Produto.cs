using System;

namespace Cardapio.Domain
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string ImagemUrl { get; set; } = string.Empty;

        public PedidoItem? PedidoItem { get; set; }
    }
}
