using Microsoft.EntityFrameworkCore;
using TarefasApi.data;
using TarefasApi.repositories;
using TarefasApi.services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers (MVC)
builder.Services.AddControllers();

// Configura o DbContext com a string de conexão
string? stringConnection = builder.Configuration.GetConnectionString("StringConexaoBanco");
if (stringConnection is null)
    throw new Exception("A string de conexão definida é nula.");

builder.Services.AddDbContext<TarefasApiContext>(opt =>
    opt.UseSqlServer(stringConnection));

// Injeta repositórios e serviços
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<TarefaReposiory>();
builder.Services.AddScoped<TarefaService>();

var app = builder.Build();

// Middleware padrão
app.UseHttpsRedirection();

// Mapeia os controllers
app.MapControllers();

app.Run();
