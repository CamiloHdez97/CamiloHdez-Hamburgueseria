using API.Dtos;
using Dominio.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Chef, ChefDto>().ReverseMap();
            CreateMap<Hamburguesa, HamburguesaDto>().ReverseMap();
            CreateMap<Ingrediente, IngredienteDto>().ReverseMap();
           // CreateMap<HamburguesaIngrediente, HamburguesaIngredienteDto>().ReverseMap();

            //Herencia

            // CreateMap<Person, PersonxIncidenceDto>().ReverseMap();
            // CreateMap<Region, RegionxCityDto>().ReverseMap();
            // CreateMap<Country, CountryXRegDto>().ReverseMap();
        }
    }
}