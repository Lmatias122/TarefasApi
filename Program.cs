using Microsoft.EntityFrameworkCore;
using TarefasApi.data;
using TarefasApi.repositories;
using TarefasApi.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

string? stringConnection = builder.Configuration.GetConnectionString("StringConexaoBanco");

if (stringConnection is null)
    throw new Exception("A string de conexão definida é nula.");

//Adicao ID dbcontext
builder.Services.AddDbContext<TarefasApiContext>
(
    opt => opt.UseSqlServer(stringConnection)
);

//Adicao ID service / repository
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
