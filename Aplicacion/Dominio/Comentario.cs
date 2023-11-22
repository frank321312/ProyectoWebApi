using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Comentario")]
public class Comentario
{
    [Key]
    [Required]
    public Guid IdComentario { get; set; } = Guid.NewGuid();

    [ForeignKey("IdUsuario")]
    public Usuario? UsuarioComentario { get; set; } = null;

    [Required]
    public DateTime FechaComentario { get; set; } = DateTime.Now;

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