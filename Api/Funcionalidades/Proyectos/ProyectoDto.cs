using Api.Funcionalidades.Tickets;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Proyectos;

public class ProyectoCommandDto
{
    public required string Nombre { get; set; }
}

public class ProyectoQueryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public List<TicketQueryDto> Tickets { get; set; } = new List<TicketQueryDto>();
    public List<UsuarioQueryDto> Usuarios { get; set; } = new List<UsuarioQueryDto>();
}