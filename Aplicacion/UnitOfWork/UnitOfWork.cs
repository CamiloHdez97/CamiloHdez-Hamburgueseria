

using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private HamburguesaRepository _hamburguesa;
    private CategoriaRepository _categoria;
    private ChefRepository _chef;
    private IngredienteRepository _ingrediente;
    private readonly ApiDbContext _context;
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IHamburguesaRepository Hamburguesas
     {
         get
         {
             if (_hamburguesa is not  null)
             {
                 return _hamburguesa = new HamburguesaRepository(_context);
             }
             return _hamburguesa;
         }
     }
    public ICategoriaRepository Categorias
     {
         get
         {
             if (_categoria is not null)
             {
                 return _categoria = new CategoriaRepository(_context);
             }
             return _categoria;
         }
     }

    public IChefRepository Chefs
     {
         get
         {
             if (_chef is not null)
             {
                 return _chef;
             }
             return _chef = new ChefRepository(_context);
         }
     }

    public IIngredienteRepository Ingredientes
     {
         get
         {
             if (_ingrediente is not null)
             {
                 return _ingrediente;
             }
             return _ingrediente = new IngredienteRepository(_context);
         }
     }
     
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

}