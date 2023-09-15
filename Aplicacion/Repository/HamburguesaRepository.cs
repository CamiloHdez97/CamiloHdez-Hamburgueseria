using Dominio;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class HamburguesaRepository : GenericRepository<Hamburguesa>, IHamburguesaRepository {
    public HamburguesaRepository(ApiDbContext context) : base(context) {
    }
}