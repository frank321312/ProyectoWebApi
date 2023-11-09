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
    public string Estado { get; set; } = string.Empty;
    // public Actividad ActividadTicket { get; set; } 
    public Ticket()
    {
        // UsuarioTicket = null;
    }
    public Ticket(string nombre)
    {
        Nombre = nombre;
        Estado = "Abierto";
    }

    public void AgregarUsuario(Usuario usuario) => UsuarioTicket = usuario;
}