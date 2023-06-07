using Microsoft.EntityFrameworkCore;

namespace AluraLoja
{
    internal class LojaContexto : DbContext
    {
        static readonly string stringDeConexao = "Server=localhost; User ID=root; Password=root; Database=alura_store";
        
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));
        }
    }
}