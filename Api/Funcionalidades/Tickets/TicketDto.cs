using Aplicacion.Dominio;
using Api.Funcionalidades.Comentarios;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Tickets;

public class TicketCommandDto
{
    public required string Nombre { get; set; }
}

public class TicketQueryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public UsuarioQueryDto? UsuarioTicket { get; set; } = null;
    public string Estado { get; set; } = "Abierto";
    public ComentarioQueryDto? ComentarioTicket { get; set; } = null;
    public DateTime FechaTicket { get; set; } = DateTime.Now;
}
