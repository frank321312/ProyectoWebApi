using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;

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
        return context.tickets.Select(x => new TicketQueryDto { Id = x.Id, Nombre = x.Nombre, UsuarioTicket = x.UsuarioTicket, Estado = x.Estado }).ToList();
    }
}

