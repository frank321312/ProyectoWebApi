using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Proyecto")]
public class Proyecto
{
    [Key]
    [Required]
    public Guid IdProject { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(45)]
    public string Nombre { get; set; } = string.Empty;
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public Proyecto(string nombre)
    {
        Nombre = nombre;
    }
    public void AgregarTicket(Ticket ticket) => Tickets.Add(ticket);

    public void EliminarTicket(Ticket ticket) => Tickets.Remove(ticket);

    public void AgregarUsuario(Usuario usuario) => Usuarios.Add(usuario);

    public void EliminarUsuario(Usuario usuario) => Usuarios.Remove(usuario);

    public void AgregarUsuarioTicket(Ticket ticket, Usuario usuario) => ticket.AgregarUsuario(usuario);

    public void CrearTicket(Ticket ticket) => Tickets.Add(ticket);
    public void AsignarUsuario(Guid ticketId, Usuario usuario)
    {
        var ticket = Tickets.Where(x => x.Id == ticketId).ToList();

        foreach (var index in ticket)
        {
            if (index.Id == ticketId)
            {
                index.UsuarioTicket = usuario;
            }
        }
    }
}
