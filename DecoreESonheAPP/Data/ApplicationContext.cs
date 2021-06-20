using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DecoreESonheAPP.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Informar qual é o provider a utilizar
            string stringConnection = "Server=.\\SQLEXPRESS;Database=DecoreeSonheAPP;User=sa;Password=abcd.1234;ConnectRetryCount=0;MultipleActiveResultSets=true";
            optionsBuilder
                .UseSqlServer(stringConnection,
                    p => p.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null).MigrationsHistoryTable("DecoreeSonheAPP"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
