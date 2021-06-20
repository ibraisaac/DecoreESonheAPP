using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoreESonheAPP.Data.Configuration
{
    public class TipoProdutosConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.ToTable("TipoProdutos");
            builder.HasKey(c => c.Identificador);
            builder.Property(c => c.Codigo).HasColumnType("int").IsRequired();
            builder.Property(c => c.Descricao).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
