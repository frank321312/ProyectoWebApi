namespace Api.Funcionalidades.Usuarios;

public class UsuarioCommandDto
{
    public required string Nombre { get; set; }
}

public class UsuarioQueryDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}