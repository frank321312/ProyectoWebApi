using Microsoft.AspNetCore.Mvc;
using Carter;
using Api.Funcionalidades.Tickets;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Proyectos;

public class ProyectoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/proyecto", ([FromServices]IProyectoService proyectoService) => {
            return Results.Ok(proyectoService.GetProyectos());
        });

        app.MapPost("/api/proyecto/{proyectoId}/ticket", ([FromServices]IProyectoService proyectoService, TicketCommandDto ticketCommandDto, Guid proyectoId) => {
            proyectoService.CreateTicketProject(ticketCommandDto, proyectoId);
                
            return Results.Ok();
        });

        app.MapPost("/api/proyecto", ([FromServices]IProyectoService proyectoService, ProyectoCommandDto proyectoCommandDto) => {
            proyectoService.CreateProject(proyectoCommandDto);
                
            return Results.Ok();
        });

        app.MapPost("/api/proyecto/{proyectoId}/usuario", ([FromServices]IProyectoService proyectoService, UsuarioCommandDto usuarioCommandDto, Guid proyectoId) => {
            proyectoService.CreateUser(usuarioCommandDto, proyectoId);
                
            return Results.Ok();
        });

        app.MapDelete("/api/proyecto/{ticketId}/ticket", ([FromServices]IProyectoService proyectoService, Guid ticketId) => {
            proyectoService.DeleteTicket(ticketId);
                
            return Results.Ok();
        });

        // app.MapDelete("/api/proyecto/{usuarioId}/usuario", ([FromServices]IProyectoService proyectoService, Guid usuarioId) => {
        //     proyectoService.DeleteUsuario(usuarioId);
                
        //     return Results.Ok();
        // });

        app.MapPut("/api/proyecto/{ticketId}/{usuarioId}", ([FromServices]IProyectoService proyectoService, Guid ticketId, Guid usuarioId) => {
            proyectoService.AsignarActividad(ticketId, usuarioId);
                
            return Results.Ok();
        });

        app.MapPut("/api/proyecto/{ticketId}/estado", ([FromServices]IProyectoService proyectoService, Guid ticketId, string estado) => {
            proyectoService.ModifcarEstadoTicket(ticketId, estado);
                
            return Results.Ok();
        });

        app.MapDelete("/api/proyecto/{usuarioId}/usuario", ([FromServices]IProyectoService proyectoService, Guid usuarioId) => {
            proyectoService.DeleteUsuarioProject(usuarioId);
                
            return Results.Ok();
        });
    }
}