using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [Required]
    public Guid Id { get; set;} = Guid.NewGuid();
    
    [Required]
    [StringLength(45)]
    public string Nombre { get; set;} = string.Empty;
    public Usuario()
    {
    }
    public Usuario(string unNombre)
    {
        Nombre = unNombre;
    }
}
