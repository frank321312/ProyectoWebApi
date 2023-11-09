using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.Tickets;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Proyectos;

public interface IProyectoService
{
    List<ProyectoQueryDto> GetProyectos();
    void AddProjectTicket(Guid ticketId, Guid proyectoId);
    void DeleteProjectTicket(Guid ticketId, Guid proyectoId);
    void AddProjectUsuario(Guid usuarioId, Guid proyectoId);
    void DeleteProjectUsuario(Guid usuarioId, Guid proyectoId);
    void AddUsuarioTicketProject(Guid usuarioId, Guid ticketId, Guid proyectoId);
    void CreateTicketProject(TicketCommandDto ticketCommandDto, Guid proyectoId);
    // void UpdateTicketProject(Guid ticketId, Guid proyectoId);
} 

public class ProyectoService : IProyectoService
{
    private readonly ProyectoDbContext context;
    public ProyectoService(ProyectoDbContext context)
    {
        this.context = context;
    }
    public List<ProyectoQueryDto> GetProyectos()
    {
        return context.proyectos
            .Include(x => x.Tickets)
            .Select(x => new ProyectoQueryDto
            {
                Id = x.IdProject,
                Tickets = x.Tickets.Select(y => new TicketQueryDto { Id = y.Id, Nombre = y.Nombre, UsuarioTicket = y.UsuarioTicket}).ToList(),
                Usuarios = x.Usuarios.Select(y => new UsuarioQueryDto { Id = y.Id, Nombre = y.Nombre }).ToList()
            }).ToList();
    }

    public void AddProjectTicket(Guid ticketId, Guid proyectoId)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (ticket != null && proyecto != null)
        {
            proyecto.AgregarTicket(ticket);

            context.SaveChanges();
        }
    }

    public void DeleteProjectTicket(Guid ticketId, Guid proyectoId)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (ticket != null && proyecto != null)
        {
            proyecto.EliminarTicket(ticket);

            context.SaveChanges();
        }
    }

    public void AddProjectUsuario(Guid usuarioId, Guid proyectoId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (usuario != null && proyecto != null)
        {
            proyecto.AgregarUsuario(usuario);

            context.SaveChanges();
        }
    }

    public void DeleteProjectUsuario(Guid usuarioId, Guid proyectoId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (usuario != null && proyecto != null)
        {
            proyecto.EliminarUsuario(usuario);

            context.SaveChanges();
        }
    }

    public void AddUsuarioTicketProject(Guid usuarioId, Guid ticketId, Guid proyectoId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (usuario != null && ticket != null && proyecto != null)
        {
            proyecto.AgregarUsuarioTicket(ticket, usuario);

            context.SaveChanges();
        }
    }

    public void CreateTicketProject(TicketCommandDto ticketCommandDto, Guid proyectoId)
    {
        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        proyecto.CrearTicket(new Ticket(ticketCommandDto.Nombre));

        context.SaveChanges();

    }
}