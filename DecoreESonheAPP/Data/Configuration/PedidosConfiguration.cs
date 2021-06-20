using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoreESonheAPP.Data.Configurations
{
    public class PedidosConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(c => c.Identificador);
            builder.Property(c => c.Codigo).HasColumnType("int").IsRequired();
            builder.Property(c => c.DataPedido).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.DataEntrega).HasColumnType("Date");
            builder.Property(c => c.DataPagamento).HasColumnType("Date");
            builder.Property(c => c.Status).HasConversion<string>().IsRequired();
            builder.Property(c => c.TipoEntrega).HasConversion<string>();
            builder.Property(c => c.TipoPagamento).HasConversion<string>();
            builder.Property(c => c.CanalVenda).HasConversion<string>();
            builder.Property(c => c.IdCliente).IsRequired();
            builder.Property(c => c.Observacao).HasColumnType("Varchar(500)");

            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}