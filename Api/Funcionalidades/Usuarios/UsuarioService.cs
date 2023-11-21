using Aplicacion.Dominio;
using Api.Persistencia;

namespace Api.Funcionalidades.Usuarios;

public interface IUsuarioService
{
    List<UsuarioQueryDto> GetUsuarios();
}

public class UsuarioService : IUsuarioService
{
    private readonly ProyectoDbContext context;

    public UsuarioService(ProyectoDbContext context)
    {
        this.context = context;
    }
    public List<UsuarioQueryDto> GetUsuarios()
    {
        return context.usuarios.Select(x => new UsuarioQueryDto { Id = x.Id, Nombre = x.Nombre }).ToList();
    }
}

