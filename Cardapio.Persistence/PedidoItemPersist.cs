using Cardapio.Domain;
using Cardapio.Persistence.Contexto;
using Cardapio.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence
{
    public class PedidoItemPersist : IPedidoItemPersist
    {
        private readonly CardapioContext _context;
        public PedidoItemPersist(CardapioContext context)
        {
            _context = context;
        }

        public async Task<PedidoItem[]> GetAllPedidoItensAsync()
        {
            IQueryable<PedidoItem> query = _context.pedidoItem;

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<PedidoItem> GetPedidoByIdAsync(int pedidoItemId)
        {
            IQueryable<PedidoItem> query = _context.pedidoItem;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(p => p.Id == pedidoItemId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
