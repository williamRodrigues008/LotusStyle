using LotusStyle.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace LotusStyle.API.Datas.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CodProduto).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Imagem).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Preco).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LinhaProduto).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NacionalImportado).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Tipo).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Marca).HasMaxLength(100).IsRequired();
        }
    }
}
