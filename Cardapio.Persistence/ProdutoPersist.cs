using Cardapio.Domain;
using Cardapio.Persistence.Contexto;
using Cardapio.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.Persistence
{
    public class ProdutoPersist : IProdutoPersist
    {
        private readonly CardapioContext _context;
        public ProdutoPersist(CardapioContext context)
        {
            _context = context;
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.produto;

            query = query.AsNoTracking().OrderBy(e=>e.Id);

            return await query.ToArrayAsync();
        }

        public Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            IQueryable<Produto> query = _context.produto;
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(p=>p.Id == produtoId);

            return query.FirstOrDefaultAsync();
        }
    }
}
