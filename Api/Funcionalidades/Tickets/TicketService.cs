using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Comentarios;

namespace Api.Funcionalidades.Tickets;

public interface ITicketService
{
    List<TicketQueryDto> GetTickets();
}

public class TicketService : ITicketService
{
    private readonly ProyectoDbContext context;

    public TicketService(ProyectoDbContext context)
    {
        this.context = context;
    }
    public List<TicketQueryDto> GetTickets()
    {
        return context.tickets.Select(x => new TicketQueryDto { Id = x.Id, Nombre = x.Nombre, UsuarioTicket = x.UsuarioTicket != null ? new UsuarioQueryDto { Id = x.UsuarioTicket.Id, Nombre = x.UsuarioTicket.Nombre } : null, Estado = x.Estado, ComentarioTicket = x.ComentarioTicket != null ? new ComentarioQueryDto { IdComentario = x.ComentarioTicket.IdComentario, UsuarioComentario = x.ComentarioTicket.UsuarioComentario != null ? new UsuarioQueryDto { Id = x.ComentarioTicket.UsuarioComentario.Id, Nombre = x.ComentarioTicket.UsuarioComentario.Nombre } : null, Contenido = x.ComentarioTicket.Contenido, FechaComentario = x.ComentarioTicket.FechaComentario } : null }).ToList();
    }
}

// Token: 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