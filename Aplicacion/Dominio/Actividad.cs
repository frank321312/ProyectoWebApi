namespace Aplicacion.Dominio;

public class Actividad
{
    public Ticket TicketComentario { get; set; }
    public Comentario ComentarioActividad { get; set; }
    public Actividad(Ticket ticket, Comentario comentar)
    {
        TicketComentario = ticket;        
        ComentarioActividad = comentar;
    }
}