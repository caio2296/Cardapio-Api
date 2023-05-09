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
     public class PedidoPersist : IPedidoPersist
    {
        private readonly CardapioContext _context;

        public PedidoPersist(CardapioContext context)
        {
            _context = context;
        }
        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            IQueryable<Pedido> query = _context.pedido;

            query = query.AsNoTracking().OrderBy(e=> e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pedido> GetPedidoByIdAsync(int pedidoId)
        {
            IQueryable<Pedido> query = _context.pedido;

            query = query.AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(p => p.Id == pedidoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
