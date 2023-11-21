using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Usuarios;

public class UsuarioEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/usuario", ([FromServices] IUsuarioService usuarioService) =>
        {
            return Results.Ok(usuarioService.GetUsuarios());
        });

        app.MapDelete("/api/usuario/{usuarioId}", ([FromServices] IUsuarioService usuarioService, Guid usuarioId) =>
        {
            usuarioService.DeleteUser(usuarioId);

            return Results.Ok();
        });

        app.MapPost("/api/usuario", ([FromServices] IUsuarioService usuarioService, UsuarioCommandDto usuarioCommandDto) =>
        {
            usuarioService.CreateUser(usuarioCommandDto);

            return Results.Ok();
        });
    }
}