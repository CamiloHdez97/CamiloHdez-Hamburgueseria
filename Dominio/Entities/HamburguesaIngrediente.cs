namespace Dominio.Entities
{
    public class HamburguesaIngrediente
    {
    public int hamburguesa_id { get; set; }
    public Hamburguesa Hamburguesa { get; set; }
    public int ingrediente_id { get; set; }
    public Ingrediente Ingrediente { get; set; }    
    
    }
}