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
    }
}