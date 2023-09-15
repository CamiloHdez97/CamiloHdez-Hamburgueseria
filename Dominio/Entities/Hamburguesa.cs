namespace Dominio.Entities
{
    public class Hamburguesa:BaseEntity
    {
    public string Nombre { get; set; }
    public int Categoria_id { get; set; }
    public Categoria Categoria { get; set; }
    public int Precio { get; set; }
    public int chef_id { get; set; }
    public Chef Chef { get; set; }
    public ICollection<Ingrediente> Ingredientes { get; set; } = new HashSet<Ingrediente>();
    public ICollection<HamburguesaIngrediente> HamburguesaIngredientes { get; set; }
    }
}