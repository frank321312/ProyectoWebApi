using Api.Persistencia;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Comentarios;

public interface IComentarioService
{
    List<ComentarioQueryDto> GetComentarios();
}

public class ComentarioService : IComentarioService
{
    private readonly ProyectoDbContext context;

    public ComentarioService(ProyectoDbContext context)
    {
        this.context = context;
    }

    public List<ComentarioQueryDto> GetComentarios()
    {
        return context.comentarios.Select(x => new ComentarioQueryDto { IdComentario = x.IdComentario, Contenido = x.Contenido, UsuarioComentario = x.UsuarioComentario != null ? new UsuarioQueryDto { Id = x.UsuarioComentario.Id, Nombre = x.UsuarioComentario.Nombre } : null, FechaComentario = x.FechaComentario }).ToList();
    }
}
