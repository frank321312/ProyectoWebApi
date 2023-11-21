using Microsoft.EntityFrameworkCore;
using Aplicacion.Dominio;

namespace Api.Persistencia;

public class ProyectoDbContext : DbContext
{
    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> opciones) : base(opciones)
    {
    }

    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Ticket> tickets { get; set; }
    public DbSet<Proyecto> proyectos { get; set; }
    public DbSet<Comentario> comentarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario("User_1"),
            new Usuario("User_2"),
            new Usuario("User_3")
        );

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket("Programacion"),
            new Ticket("Analisis"),
            new Ticket("Logica")
        );

        modelBuilder.Entity<Proyecto>().HasData(
            new Proyecto("Proyecto_1"),
            new Proyecto("Proyecto_2"),
            new Proyecto("Proyecto_3")
        );
    }
}