using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Tickets;

public class TicketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/ticket", ([FromServices]ITicketService ticketService) => {
            return Results.Ok(ticketService.GetTickets());
        });
    
        app.MapPost("/api/ticket", ([FromServices]ITicketService ticketService, TicketCommandDto ticketCommandDto) => {
            ticketService.CreateTicket(ticketCommandDto);
            
            return Results.Ok();
        });

        app.MapPut("/api/ticket/{ticketId}", ([FromServices]ITicketService ticketService, Guid ticketId, TicketCommandDto ticketCommandDto) => {
            ticketService.UpdateTicket(ticketId, ticketCommandDto);
            
            return Results.Ok();
        });

        app.MapDelete("/api/ticket/{ticketId}", ([FromServices]ITicketService ticketService, Guid ticketId) => {
            ticketService.DeleteTicket(ticketId);
            
            return Results.Ok();
        });

        app.MapPost("/api/ticket/{ticketId}/usuario/{usuarioId}", ([FromServices]ITicketService ticketService, Guid ticketId, Guid usuarioId) => {
            ticketService.AddUsuario(usuarioId, ticketId);
            
            return Results.Ok();
        });
    }
}