using Api.Funcionalidades.Tickets;
using Api.Funcionalidades;
using Carter;
using Api.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServicesManager();
builder.Services.AddCarter();

var connectionString = builder.Configuration.GetConnectionString("proyecto_db");

builder.Services.AddDbContext<ProyectoDbContext>(opcion =>
    opcion.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34))));

builder.Services.AddDbContext<ProyectoDbContext>();

var opciones = new DbContextOptionsBuilder<ProyectoDbContext>();

opciones.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));

var contexto = new ProyectoDbContext(opciones.Options);

contexto.Database.EnsureCreated();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapTicketEndpoints();
app.MapCarter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();