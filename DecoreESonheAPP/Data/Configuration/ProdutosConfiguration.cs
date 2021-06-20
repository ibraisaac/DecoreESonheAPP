using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoreESonheAPP.Data.Configurations
{
    public class ProdutosConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(c => c.Identificador);
            builder.Property(c => c.Codigo).HasColumnType("Varchar(20)").IsRequired();
            builder.Property(c => c.Descricao).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.IdTipoProduto).HasColumnType("int").IsRequired();

        }
    }
}