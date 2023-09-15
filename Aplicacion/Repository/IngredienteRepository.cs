using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class IngredienteRepository : GenericRepository<Ingrediente>, IIngredienteRepository {
    public IngredienteRepository(ApiDbContext context) : base(context) {
    }
}
