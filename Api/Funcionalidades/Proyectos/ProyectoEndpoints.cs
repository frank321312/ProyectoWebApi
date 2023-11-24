using Microsoft.AspNetCore.Mvc;
using Carter;
using Api.Funcionalidades.Tickets;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Comentarios;

namespace Api.Funcionalidades.Proyectos;

public class ProyectoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/proyecto", ([FromServices] IProyectoService proyectoService) =>
        {
            return Results.Ok(proyectoService.GetProyectos());
        });

        app.MapPost("/api/proyecto/{proyectoId}/ticket", ([FromServices] IProyectoService proyectoService, TicketCommandDto ticketCommandDto, Guid proyectoId) =>
        {
            proyectoService.CreateTicketProject(ticketCommandDto, proyectoId);

            return Results.Ok();
        });

        app.MapPost("/api/proyecto", ([FromServices] IProyectoService proyectoService, ProyectoCommandDto proyectoCommandDto) =>
        {
            proyectoService.CreateProject(proyectoCommandDto);

            return Results.Ok();
        });

        app.MapDelete("/api/ticket/{ticketId}/", ([FromServices] IProyectoService proyectoService, Guid ticketId) =>
        {
            proyectoService.DeleteTicket(ticketId);

            return Results.Ok();
        });

        app.MapPut("/api/ticket/{ticketId}/usuario/{usuarioId}", ([FromServices] IProyectoService proyectoService, Guid ticketId, Guid usuarioId) =>
        {
            proyectoService.AsignarActividad(ticketId, usuarioId);

            return Results.Ok();
        });

        app.MapPut("/api/ticket/{ticketId}/estado", ([FromServices] IProyectoService proyectoService, Guid ticketId, string estado) =>
        {
            proyectoService.ModifcarEstadoTicket(ticketId, estado);

            return Results.Ok();
        });

        app.MapDelete("/api/usuario/{usuarioId}/ticket{ticketId}", ([FromServices] IProyectoService proyectoService, Guid usuarioId, Guid ticketId) =>
        {
            proyectoService.DeleteUsuarioProject(usuarioId, ticketId);

            return Results.Ok();
        });

        app.MapPost("/api/proyecto/{proyectoId}/usuario/{usuarioId}", ([FromServices] IProyectoService proyectoService, Guid usuarioId, Guid proyectoId) =>
        {
            proyectoService.AsignarUsuarioProyecto(usuarioId, proyectoId);

            return Results.Ok();
        });

        app.MapPost("/api/usuario/{usuarioId}/ticket/{ticketId}/comentario", ([FromServices] IProyectoService proyectoService, Guid ticketId, Guid usuarioId, ComentarioDto comentarioDto) =>
        {
            proyectoService.CrearComentario(ticketId, usuarioId, comentarioDto);

            return Results.Ok();
        });
    }
}