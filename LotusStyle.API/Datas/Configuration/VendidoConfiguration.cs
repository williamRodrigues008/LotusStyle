using LotusStyle.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotusStyle.API.Datas.Configuration
{
    public class VendidoConfiguration : IEntityTypeConfiguration<ProdutoVendido>
    {
        public void Configure(EntityTypeBuilder<ProdutoVendido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.IdProduto);
            builder.Property(x => x.DataVenda).IsRequired();

            builder.HasOne(x => x.Produto)
                .WithOne(x => x.Vendido)
                .HasForeignKey<ProdutoVendido>(x => x.IdProduto)
                .IsRequired();
        }
    }
}
