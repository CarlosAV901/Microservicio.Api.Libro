using Microsoft.EntityFrameworkCore;
using TiendaMicroservicio.Api.Libro.Modelo;

namespace TiendaMicroservicio.Api.Libro.Persistencia;

public class ContextoLibreria : DbContext
{
    public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
    {
        
    }
    
    public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
}