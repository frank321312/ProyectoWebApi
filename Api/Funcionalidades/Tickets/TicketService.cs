using Aplicacion.Dominio;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Tickets;

public interface ITicketService
{
    List<TicketQueryDto> GetTickets();
    void CreateTicket(TicketCommandDto ticketCommandDto);
    void UpdateTicket(Guid ticketId, TicketCommandDto ticketCommandDto);
    void DeleteTicket(Guid ticketId);
    void AddUsuario(Guid usuarioId, Guid ticketId);
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
    public void CreateTicket(TicketCommandDto ticketCommandDto)
    {
        context.tickets.Add(new Ticket(ticketCommandDto.Nombre));
        
        context.SaveChanges();
    }

    public void UpdateTicket(Guid ticketId, TicketCommandDto ticketCommandDto)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);
        
        if (ticket != null)
        {
            ticket.Nombre = ticketCommandDto.Nombre;
            context.SaveChanges();
        }
    }

    public void DeleteTicket(Guid ticketId)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (ticket != null)
        {
            context.tickets.Remove(ticket);

            context.SaveChanges();
        }
    }

    public void AddUsuario(Guid usuarioId, Guid ticketId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (usuario != null && ticket != null)
        {
            ticket.AgregarUsuario(usuario);

            context.SaveChanges();
        }
    }
}

