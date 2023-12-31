using Api.Funcionalidades.Tickets;
using Api.Funcionalidades.Proyectos;
using Api.Funcionalidades.Usuarios;
using Api.Funcionalidades.Comentarios;

namespace Api.Funcionalidades;

public static class ServicesManager
{
    public static IServiceCollection AddServicesManager(this IServiceCollection services)
    {
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IProyectoService, ProyectoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IComentarioService, ComentarioService>();

        return services;
    }
}
