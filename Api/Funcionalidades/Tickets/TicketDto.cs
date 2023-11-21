using Aplicacion.Dominio;
using Api.Funcionalidades.Comentarios;

namespace Api.Funcionalidades.Tickets;

public class TicketCommandDto
{
    public required string Nombre { get; set; }
}

public class TicketQueryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public Usuario? UsuarioTicket { get; set; } = null;
    public string Estado { get; set; } = "Abierto";
    public Comentario? ComentarioTicket { get; set; } = null;
}
