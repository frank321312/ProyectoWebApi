using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Usuarios;

public class UsuarioEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/usuario", ([FromServices]IUsuarioService usuarioService) => {
            return Results.Ok(usuarioService.GetUsuarios());
        });

        app.MapPost("/api/usuario", ([FromServices]IUsuarioService usuarioService, UsuarioCommandDto usuarioCommandDto) => {
            usuarioService.CreateUsuario(usuarioCommandDto);
            
            return Results.Ok();
        });

        app.MapPut("/api/usuario/{usuarioId}", ([FromServices]IUsuarioService usuarioService, Guid usuarioId, UsuarioCommandDto usuarioCommandDto) => {
            usuarioService.UpdateUsuario(usuarioId, usuarioCommandDto);
            
            return Results.Ok();
        });

        app.MapDelete("/api/usuario/{usuarioId}", ([FromServices]IUsuarioService usuarioService, Guid usuarioId) => {
            usuarioService.DeleteUsuario(usuarioId);
            
            return Results.Ok();
        });
    }
}