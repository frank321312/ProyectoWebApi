using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Comentario")]
public class Comentario
{
    [ForeignKey("IdUsuario")]
    public Usuario? UsuarioComentario { get; set; } = null;

    [Required]
    public DateTime? FechaComentario { get; set; } = null;
    
    [Required]
    public string Contenido { get; set; } = string.Empty;
    
    public Comentario()
    {
        
    }
    public Comentario(string unContenido)
    {
        Contenido = unContenido;
    }
}