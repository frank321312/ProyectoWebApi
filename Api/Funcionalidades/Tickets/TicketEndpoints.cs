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
    }
}