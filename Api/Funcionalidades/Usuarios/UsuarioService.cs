using Aplicacion.Dominio;
using Api.Persistencia;

namespace Api.Funcionalidades.Usuarios;

public interface IUsuarioService
{
    List<UsuarioQueryDto> GetUsuarios();
    void CreateUsuario(UsuarioCommandDto usuarioCommandDto);
    void UpdateUsuario(Guid usuarioId, UsuarioCommandDto usuarioCommandDto);
    void DeleteUsuario(Guid usuarioId);
}

public class UsuarioService : IUsuarioService
{
    private readonly ProyectoDbContext context;

    public UsuarioService(ProyectoDbContext context)
    {
        this.context = context;
    }
    public List<UsuarioQueryDto> GetUsuarios()
    {
        return context.usuarios.Select(x => new UsuarioQueryDto { Id = x.Id, Nombre = x.Nombre }).ToList();
    }

    public void CreateUsuario(UsuarioCommandDto usuarioCommandDto)
    {
        context.usuarios.Add(new Usuario(usuarioCommandDto.Nombre));
        
        context.SaveChanges();
    }

    public void UpdateUsuario(Guid usuarioId, UsuarioCommandDto usuarioCommandDto)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);
        
        if (usuario != null)
        {
            usuario.Nombre = usuarioCommandDto.Nombre;
            context.SaveChanges();
        }
    }

    public void DeleteUsuario(Guid usuarioId)
    {
        var usuario = context.usuarios.FirstOrDefault(x => x.Id == usuarioId);

        if (usuario != null)
        {
            context.usuarios.Remove(usuario);

            context.SaveChanges();
        }
    }

}