using Cardapio.Persistence.Contexto;
using Cardapio.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace Cardapio.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly CardapioContext _context;
        public GeralPersist(CardapioContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
