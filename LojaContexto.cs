using AluraLoja.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraLoja
{
    internal class LojaContexto : DbContext
    {
        static readonly string stringDeConexao = "Server=localhost; User ID=root; Password=root; Database=alura_store";
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));
        }
    }
}