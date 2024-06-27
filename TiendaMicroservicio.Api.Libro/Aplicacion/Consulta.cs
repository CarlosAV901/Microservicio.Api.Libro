using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaMicroservicio.Api.Libro.Modelo;
using TiendaMicroservicio.Api.Libro.Persistencia;

namespace TiendaMicroservicio.Api.Libro.Aplicacion;

public class Consulta
{
    public class Ejecuta : IRequest<List<LibroMaterialDto>>
    {
        public Ejecuta()
        {
            
        }
    }
    
    public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
    {
        private readonly ContextoLibreria _contexto;
        private readonly IMapper _mapper;

        public Manejador(ContextoLibreria contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var libros = await _contexto.LibreriaMaterial.ToListAsync();
            var libroDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);
            return libroDto;
        }
    }
}