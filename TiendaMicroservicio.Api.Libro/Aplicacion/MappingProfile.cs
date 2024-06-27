using AutoMapper;
using TiendaMicroservicio.Api.Libro.Modelo;

namespace TiendaMicroservicio.Api.Libro.Aplicacion;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LibreriaMaterial, LibroMaterialDto>();
    }
}