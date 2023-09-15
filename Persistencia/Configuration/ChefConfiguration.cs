using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.ToTable("chefs");

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

            builder.Property(p => p.Especialidad)
                .HasColumnName("especialidad")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}