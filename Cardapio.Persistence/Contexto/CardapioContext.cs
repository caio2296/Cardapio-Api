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

        public DbSet<Produto> produto { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<PedidoItem> pedidoItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .HasOne(pi => pi.PedidoItem)
                .WithOne(pr => pr.Produto);

            modelBuilder.Entity<PedidoItem>()
                .HasOne(p => p.Pedido)
                .WithMany(p => p.ItemPedidos)
                .HasForeignKey(p => p.ProdutoId)
                .HasForeignKey(pe => pe.PedidoId)
                .IsRequired(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(pi => pi.ItemPedidos)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);
        }
    }
}
