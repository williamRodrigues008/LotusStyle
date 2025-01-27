using LotusStyle.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotusStyle.API.Datas
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoVendido> ProdutoVendido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContexto).Assembly);
        }

    }
}
