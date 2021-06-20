using DecoreESonheAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoreESonheAPP.Data.Configurations
{
    public class ClientesConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Identificador);
            builder.Property(c => c.Nome).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(11)").HasMaxLength(11).IsRequired();
            builder.Property(c => c.CEP).HasColumnType("varchar(8)").HasMaxLength(8).IsRequired();
            builder.Property(c => c.Estado).HasColumnType("varchar(2)").HasMaxLength(2).IsRequired();
            builder.Property(c => c.Cidade).HasColumnType("varchar(50)").HasMaxLength(60).IsRequired();
            builder.Property(c => c.Endereco).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Bairro).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}