using Aplicacion.Dominio;

namespace Api.Funcionalidades.Comentarios;

public class ComentarioDto
{
    public required string Contenido { get; set; }
}

public class ComentarioQueryDto
{
    public Usuario? UsuarioComentario { get; set; } = null;
    public string Contenido { get; set; } = string.Empty;
    public DateTime? FechaComentario { get; set; } = null;
}
