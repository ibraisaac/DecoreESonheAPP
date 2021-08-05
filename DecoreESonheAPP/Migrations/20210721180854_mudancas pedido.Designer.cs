﻿// <auto-generated />
using System;
using DecoreESonheAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DecoreESonheAPP.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210721180854_mudancas pedido")]
    partial class mudancaspedido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DecoreESonheAPP.Models.Cliente", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(60);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Identificador");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.Pedido", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CanalVenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteIdentificador")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("Varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificador");

                    b.HasIndex("ClienteIdentificador");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.PedidoItem", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoIdentificador")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoIdentificador")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Identificador");

                    b.HasIndex("PedidoIdentificador");

                    b.HasIndex("ProdutoIdentificador");

                    b.ToTable("PedidoItens");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.Produto", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TipoProdutoIdentificador")
                        .HasColumnType("int");

                    b.HasKey("Identificador");

                    b.HasIndex("TipoProdutoIdentificador");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.TipoProduto", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Identificador");

                    b.ToTable("TipoProdutos");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.Pedido", b =>
                {
                    b.HasOne("DecoreESonheAPP.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdentificador");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.PedidoItem", b =>
                {
                    b.HasOne("DecoreESonheAPP.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoIdentificador")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DecoreESonheAPP.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoIdentificador");
                });

            modelBuilder.Entity("DecoreESonheAPP.Models.Produto", b =>
                {
                    b.HasOne("DecoreESonheAPP.Models.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoIdentificador");
                });
#pragma warning restore 612, 618
        }
    }
}
