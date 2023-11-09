using Microsoft.AspNetCore.Mvc;
using Carter;
using Api.Funcionalidades.Tickets;

namespace Api.Funcionalidades.Proyectos;

public class ProyectoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/proyecto", ([FromServices]IProyectoService proyectoService) => {
            return Results.Ok(proyectoService.GetProyectos());
        });

        app.MapPost("/api/proyecto/{proyectoId}/ticket/{ticketId}", ([FromServices]IProyectoService proyectoService, Guid ticketId, Guid proyectoId) => {
            proyectoService.AddProjectTicket(ticketId, proyectoId);
                
            return Results.Ok();
        });

        app.MapDelete("/api/proyecto/{proyectoId}/ticket/{ticketId}", ([FromServices]IProyectoService proyectoService, Guid ticketId, Guid proyectoId) => {
            proyectoService.DeleteProjectTicket(ticketId, proyectoId);
                
            return Results.Ok();
        });

        app.MapPost("/api/proyecto/{proyectoId}/usuario/{usuarioId}", ([FromServices]IProyectoService proyectoService, Guid usuarioId, Guid proyectoId) => {
            proyectoService.AddProjectUsuario(usuarioId, proyectoId);
                
            return Results.Ok();
        });

        app.MapDelete("/api/proyecto/{proyectoId}/usuario/{usuarioId}", ([FromServices]IProyectoService proyectoService, Guid usuarioId, Guid proyectoId) => {
            proyectoService.DeleteProjectUsuario(usuarioId, proyectoId);
                
            return Results.Ok();
        });

        app.MapPost("/api/proyecto/{proyectoId}/ticket/{ticketId}/usuario/{usuarioId}", ([FromServices]IProyectoService proyectoService, Guid ticketId, Guid usuarioId, Guid proyectoId) => {
            proyectoService.AddUsuarioTicketProject(usuarioId, ticketId, proyectoId);
                
            return Results.Ok();
        });

        app.MapPost("/api/proyecto/{proyectoId}", ([FromServices]IProyectoService proyectoService, Guid proyectoId, TicketCommandDto ticketCommandDto) => {
            proyectoService.CreateTicketProject(ticketCommandDto, proyectoId);
                
            return Results.Ok();
        });
    }
}