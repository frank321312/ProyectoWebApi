using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Comentarios;

public class UsuarioEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/comentario", ([FromServices] IComentarioService comentarioService) =>
        {
            return Results.Ok(comentarioService.GetComentarios());
        });
    }
}