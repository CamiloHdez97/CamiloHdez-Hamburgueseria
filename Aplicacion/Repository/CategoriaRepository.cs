using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository {
    public CategoriaRepository(ApiDbContext context) : base(context) {
    }
}