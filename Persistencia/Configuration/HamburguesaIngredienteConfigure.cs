using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configuration
{
    public class HamburguesaIngredienteConfiguration : IEntityTypeConfiguration<HamburguesaIngrediente>
    {
        public void Configure(EntityTypeBuilder<HamburguesaIngrediente> builder)
        {
            builder.ToTable("hamburguesa_ingrediente");
 
            builder.HasOne(ph => ph.Ingrediente)
                         .WithMany(t => t.HamburguesaIngredientes)
                         .HasForeignKey(ut => ut.ingrediente_id);

           builder.HasOne(et => et.Hamburguesa)
                         .WithMany(et => et.HamburguesaIngredientes)
                         .HasForeignKey(el => el.hamburguesa_id);

                    //  j =>
                    //  {
                    //      j.HasKey(t => new { t.Hamburguesa_id, t.Ingrediente_id });
                    //  });

        }
    }
}