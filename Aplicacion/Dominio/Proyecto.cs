using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacion.Dominio;

[Table("Proyecto")]
public class Proyecto
{
    [Key]
    [Required]
    public Guid IdProject { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(45)]
    public string Nombre { get; set; } = string.Empty;
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public Proyecto(string nombre)
    {
        Nombre = nombre;
    }
}
