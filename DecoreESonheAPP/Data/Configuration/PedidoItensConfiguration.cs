using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoreESonheAPP.Data.Configurations
{
    public class PedidoItensConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(c => c.Identificador);
            builder.Property(c => c.Quantidade).HasColumnType("int").HasDefaultValue(1).IsRequired();
            builder.Property(c => c.Valor).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.Codigo).HasColumnType("int").IsRequired();
            builder.Property(c => c.IdPedido).HasColumnType("int").IsRequired();
        }
    }
}