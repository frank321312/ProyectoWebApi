using Api.Persistencia;

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
        return context.comentarios.Select(x => new ComentarioQueryDto{ Contenido = x.Contenido, UsuarioComentario = x.UsuarioComentario, FechaComentario = x.FechaComentario}).ToList();
    }
}
