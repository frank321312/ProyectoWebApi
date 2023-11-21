using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.Tickets;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Proyectos;

public interface IProyectoService
{
    List<ProyectoQueryDto> GetProyectos();
    void CreateTicketProject(TicketCommandDto ticketCommandDto, Guid proyectoId);
    void CreateProject(ProyectoCommandDto proyectoCommandDto);
    void CreateUser(UsuarioCommandDto usuarioCommandDto, Guid proyectoId);
    void DeleteTicket(Guid ticketId);
    // void DeleteUsuario(Guid usuarioId);
    void AsignarActividad(Guid ticketId, Guid usuarioId);
    void ModifcarEstadoTicket(Guid ticketId, string estado);
    void DeleteUsuarioProject(Guid usuarioId);
    void DejarComentario(Guid ticketId, Guid usuarioId, string texto);
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
                Nombre = x.Nombre,
                Tickets = x.Tickets.Select(y => new TicketQueryDto { Id = y.Id, Nombre = y.Nombre, UsuarioTicket = y.UsuarioTicket}).ToList(),
                Usuarios = x.Usuarios.Select(y => new UsuarioQueryDto { Id = y.Id, Nombre = y.Nombre }).ToList()
            }).ToList();
    }

    public void CreateTicketProject(TicketCommandDto ticketCommandDto, Guid proyectoId)
    {
        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (proyecto != null)
        {
            var nuevoTicket = new Ticket(ticketCommandDto.Nombre);

            context.tickets.Add(nuevoTicket);

            proyecto.Tickets.Add(nuevoTicket);

            context.SaveChanges();
        }
    }

    public void CreateProject(ProyectoCommandDto proyectoCommandDto)
    {
        context.proyectos.Add(new Proyecto(proyectoCommandDto.Nombre));

        context.SaveChanges();
    }

    public void CreateUser(UsuarioCommandDto usuarioCommandDto, Guid proyectoId)
    {
        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);
        
        if (proyecto != null)
        {
            var nuevoUsuario = new Usuario(usuarioCommandDto.Nombre);

            context.usuarios.Add(nuevoUsuario);

            proyecto.Usuarios.Add(nuevoUsuario);

            context.SaveChanges();
        }
    }

    public void DeleteTicket(Guid ticketId)
    {
        var eliminarTicket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (eliminarTicket != null)
        {
            context.tickets.Remove(eliminarTicket);

            context.SaveChanges();
        }
    }

    // public void DeleteUsuario(Guid usuarioId)
    // {
    //     var eliminarUsuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

    //     if (eliminarUsuario != null)
    //     {
    //         context.usuarios.Remove(eliminarUsuario);
        
    //         context.SaveChanges();
    //     }
    // }

    public void AsignarActividad(Guid ticketId, Guid usuarioId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (ticket != null && usuario != null)
        {
            var VerificarTicket_Usuario = context.proyectos.Where(x => x.Tickets
                .Any(y => y.Id == ticketId) && x.Usuarios
                .Any(y => y.Id == usuarioId)).ToList();
            
            if (VerificarTicket_Usuario.Count > 0)
            {
                ticket.AgregarUsuario(usuario);

                context.SaveChanges();
            }
        }
    }

    public void ModifcarEstadoTicket(Guid ticketId, string estado)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (ticket != null)
        {
            ticket.Estado = estado;

            context.SaveChanges();
        }
    }

    public void DeleteUsuarioProject(Guid usuarioId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        if (usuario != null)
        {
            var Verificar_Usuario = context.proyectos
                .Where(x => x.Usuarios
                .Any(y => y.Id == usuarioId))
                .ToList();

            if (Verificar_Usuario.Count > 0)
            {
                foreach (var index_1 in Verificar_Usuario)
                {
                    index_1.Usuarios.Remove(usuario);    
                }
                
                context.SaveChanges();
            }
        }
    }

    public void DejarComentario(Guid ticketId, Guid usuarioId, string texto)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        if (ticket != null && usuario != null)
        {
            var Verificar_Usuario_Ticket = context.proyectos
                .Where(x => x.Usuarios
                .Any(y => y.Id == usuarioId))
                .ToList();

            if (Verificar_Usuario_Ticket.Count > 0)
            {
                foreach (var Listticket in Verificar_Usuario_Ticket)
                {
                    foreach (var index in Listticket.Tickets)
                    {
                        index.ComentarioTicket = 
                    }    
                }
                
                context.SaveChanges();
            }
        }
    }
}
