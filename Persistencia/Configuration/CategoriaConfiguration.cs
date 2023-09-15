using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

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
        }
    }
}