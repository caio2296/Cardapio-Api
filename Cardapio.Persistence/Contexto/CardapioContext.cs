using Cardapio.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardapio.Persistence.Contexto
{
    public class CardapioContext : DbContext
    {
        public CardapioContext(DbContextOptions<CardapioContext> options) : base(options)
        { }

        public DbSet<Produto> produtos;

        public DbSet<Pedido> pedido { get; set; }
        public DbSet<PedidoItem> pedidoItens;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PedidoItem>()
                .HasOne(p => p.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(p => p.PedidoId).HasForeignKey(p => p.ProdutoId);
        }
    }
}
