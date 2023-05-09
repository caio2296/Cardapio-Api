using Cardapio.Domain;
using Cardapio.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence
{
    public class ProdutoPersist : IProdutoPersist
    {
        public Task<Produto[]> GetAllProdutosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
