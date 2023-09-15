using Dominio;

namespace API.Dtos

{
       public class IngredienteDto
    {
        public string IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }
        public string DescripcionIngrediente { get; set; }
        public int PrecioIngrediente { get; set; }
         public int StockIngrediente { get; set; }
    }
}