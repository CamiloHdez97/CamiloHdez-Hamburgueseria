using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration
{
    public class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.ToTable("ingredientes");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Descripcion)
                .HasColumnName("descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
                
            builder.Property(p => p.Precio)
                .HasColumnName("precio")
                .HasColumnType("int")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Stock)
                .HasColumnName("stock")
                .HasColumnType("int")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
