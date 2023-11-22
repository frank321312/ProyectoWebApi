using Aplicacion.Dominio;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Comentarios;

public class ComentarioDto
{
    public required string Contenido { get; set; }
}

public class ComentarioQueryDto
{
    public Guid IdComentario { get; set; } = Guid.NewGuid();
    public UsuarioQueryDto? UsuarioComentario { get; set; } = null;
    public string Contenido { get; set; } = string.Empty;
    public DateTime FechaComentario { get; set; } = DateTime.Now;
}
