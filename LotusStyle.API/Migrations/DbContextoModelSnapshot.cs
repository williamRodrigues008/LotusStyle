﻿// <auto-generated />
using System;
using LotusStyle.API.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LotusStyle.API.Migrations
{
    [DbContext(typeof(DbContexto))]
    partial class DbContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LotusStyle.API.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodProduto")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LinhaProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NacionalImportado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasMaxLength(100)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("LotusStyle.API.Entities.ProdutoVendido", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdProduto");

                    b.ToTable("ProdutoVendido");
                });

            modelBuilder.Entity("LotusStyle.API.Entities.ProdutoVendido", b =>
                {
                    b.HasOne("LotusStyle.API.Entities.Produto", "Produto")
                        .WithOne("Vendido")
                        .HasForeignKey("LotusStyle.API.Entities.ProdutoVendido", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LotusStyle.API.Entities.Produto", b =>
                {
                    b.Navigation("Vendido");
                });
#pragma warning restore 612, 618
        }
    }
}
