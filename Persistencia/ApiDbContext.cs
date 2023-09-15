using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Dominio.Entities;

namespace Persistencia;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Hamburguesa> Hamburguesas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<HamburguesaIngrediente> HamburguesaIngredientes { get; set; }
        public DbSet<Chef> Chefs { get; set;}
        public DbSet<Categoria> Categorias { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);    
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
