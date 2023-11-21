using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Ticket")]
public class Ticket
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(45)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Descripcion { get; set; } = string.Empty;
    
    [ForeignKey("IdUsuario")]
    public Usuario? UsuarioTicket { get; set; } = null;
    
    [Required]
    public string Estado { get; set; } = "Abierto";
    public Comentario? ComentarioTicket { get; set; } = null;
    public Ticket()
    {
    }
    public Ticket(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarUsuario(Usuario usuario) => UsuarioTicket = usuario;
}