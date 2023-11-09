using Api.Funcionalidades.Tickets;
using Api.Funcionalidades.Usuarios;

namespace Api.Funcionalidades.Proyectos;

public class ProyectoCommandDto
{
}

public class ProyectoQueryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<TicketQueryDto> Tickets { get; set; } = new List<TicketQueryDto>();
    public List<UsuarioQueryDto> Usuarios { get; set; } = new List<UsuarioQueryDto>();
}