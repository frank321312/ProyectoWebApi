namespace Aplicacion.Dominio;

public class Comentario
{
    public Usuario UsuarioComentario { get; set; }
    public DateTime FechaComentario { get; set; } 
    public string Contenido { get; set; }
    public Comentario(Usuario usuario, string unContenido)
    {
        UsuarioComentario = usuario;
        FechaComentario = DateTime.Now;
        Contenido = unContenido;
    }
}