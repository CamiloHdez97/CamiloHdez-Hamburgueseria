using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration
{
    public class HamburguesaConfiguration : IEntityTypeConfiguration<Hamburguesa>
    {
        public void Configure(EntityTypeBuilder<Hamburguesa> builder)
        {
            builder.ToTable("hamburguesas");

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

            builder.HasOne(h => h.Categoria).WithMany(h => h.Hamburguesas).HasForeignKey(f => f.Categoria_id);

            builder.Property(p => p.Precio)
                .HasColumnName("precio")
                .HasColumnType("int")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(h => h.Chef).WithMany(h => h.Hamburguesas).HasForeignKey(f => f.chef_id);

            builder
                .HasMany(p => p.Ingredientes)
                .WithMany(r => r.Hamburguesas)
                .UsingEntity<HamburguesaIngrediente>(

                    j => j
                        .HasOne(et => et.Ingrediente)
                        .WithMany(et => et.HamburguesaIngredientes)
                        .HasForeignKey(el => el.ingrediente_id),

                    j => j
                        .HasOne(pt => pt.Hamburguesa)
                        .WithMany(t => t.HamburguesaIngredientes)
                        .HasForeignKey(ut => ut.hamburguesa_id),
                    j =>
                    {
                        j.HasKey(t => new { t.hamburguesa_id, t.ingrediente_id });
                    });
        }
    }
}

