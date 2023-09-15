namespace Dominio.Interfaces;

    public interface IUnitOfWork
    {
        IHamburguesaRepository Hamburguesas {get;}
        ICategoriaRepository Categorias {get;}
        IIngredienteRepository Ingredientes {get;}
        IChefRepository Chefs {get;}
        Task<int> SaveAsync();
    }
