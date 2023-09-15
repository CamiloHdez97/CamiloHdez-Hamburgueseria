using Dominio;

namespace API.Dtos

{
       public class HamburguesaDto
    {
        public string IdHamburguesa { get; set; }
        public string NombreHamburguesa { get; set; }
        public string IdCategoria { get; set; }
        public int PrecioHamburguesa { get; set; }
         public int IdChef { get; set; }
    }
}