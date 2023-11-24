using Aplicacion.Dominio;
using Api.Persistencia;
using Api.Funcionalidades.Tickets;
using Microsoft.EntityFrameworkCore;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Comentarios;

namespace Api.Funcionalidades.Proyectos;

public interface IProyectoService
{
    List<ProyectoQueryDto> GetProyectos();
    void CreateTicketProject(TicketCommandDto ticketCommandDto, Guid proyectoId);
    void CreateProject(ProyectoCommandDto proyectoCommandDto);
    void DeleteTicket(Guid ticketId);
    void AsignarActividad(Guid ticketId, Guid usuarioId);
    void ModifcarEstadoTicket(Guid ticketId, string estado);
    void DeleteUsuarioProject(Guid usuarioId, Guid ticketId);
    void AsignarUsuarioProyecto(Guid usuarioId, Guid proyectoId);
    // void ActualizarComentario(Guid ticketId, Guid usuarioId, Guid comentarioId, ComentarioDto comentarioDto);
    void CrearComentario(Guid ticketId, Guid usuarioId, ComentarioDto comentarioDto);
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
                Tickets = x.Tickets.Select(y => new TicketQueryDto { Id = y.Id, Nombre = y.Nombre, Estado = y.Estado, FechaTicket = y.FechaTicket ,UsuarioTicket = y.UsuarioTicket != null ? new UsuarioQueryDto { Id = y.UsuarioTicket.Id, Nombre = y.UsuarioTicket.Nombre } : null, ComentarioTicket = y.ComentarioTicket != null ? new ComentarioQueryDto { IdComentario = y.ComentarioTicket.IdComentario, UsuarioComentario = y.ComentarioTicket.UsuarioComentario != null ? new UsuarioQueryDto { Id = y.ComentarioTicket.UsuarioComentario.Id, Nombre = y.ComentarioTicket.UsuarioComentario.Nombre } : null, Contenido = y.ComentarioTicket.Contenido, FechaComentario = y.ComentarioTicket.FechaComentario } : null }).ToList(),
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

    public void DeleteTicket(Guid ticketId)
    {
        var eliminarTicket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (eliminarTicket != null)
        {
            context.tickets.Remove(eliminarTicket);

            context.SaveChanges();
        }
    }

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

    public void DeleteUsuarioProject(Guid usuarioId, Guid ticketId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);

        if (usuario != null && ticket != null)
        {
            var Verificar_Usuario = context.proyectos
                .Where(x => x.Usuarios
                .Any(y => y.Id == usuarioId))
                .ToList();

            if (Verificar_Usuario.Count > 0)
            {
                foreach (var index_1 in Verificar_Usuario)
                {
                    ticket.UsuarioTicket = null;
                    index_1.Usuarios.Remove(usuario);
                }

                context.SaveChanges();
            }
        }
    }

    public void AsignarUsuarioProyecto(Guid usuarioId, Guid proyectoId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);
        var proyecto = context.proyectos.FirstOrDefault(x => x.IdProject == proyectoId);

        if (usuario != null && proyecto != null)
        {
            proyecto.Usuarios.Add(usuario);

            context.SaveChanges();
        }
    }

    public void CrearComentario(Guid ticketId, Guid usuarioId, ComentarioDto comentarioDto)
    {
        var ticket = context.tickets.FirstOrDefault(x => x.Id == ticketId);
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        if (ticket != null && usuario != null)
        {
            var Verificar_Usuario_Ticket = context.proyectos
                .Where(x => x.Usuarios
                .Any(y => y.Id == usuarioId) && x.Tickets.Any(y => y.Id == ticketId))
                .ToList();

            if (Verificar_Usuario_Ticket.Count > 0)
            {
                var NuevoComentario = new Comentario(comentarioDto.Contenido);
                NuevoComentario.UsuarioComentario = usuario;

                context.comentarios.Add(NuevoComentario);

                ticket.ComentarioTicket = NuevoComentario;

                context.SaveChanges();
            }
        }
    }
}
