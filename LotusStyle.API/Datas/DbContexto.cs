using LotusStyle.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotusStyle.API.Datas
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoVendido> ProdutoVendido { get; set; }

    }
}
