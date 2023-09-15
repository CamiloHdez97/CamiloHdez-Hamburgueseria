using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class ChefRepository : GenericRepository<Chef>, IChefRepository {
    public ChefRepository(ApiDbContext context) : base(context) {
    }
}