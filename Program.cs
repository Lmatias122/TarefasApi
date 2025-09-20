using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TarefasApi.data;
using TarefasApi.Mapping;
using TarefasApi.repositories;
using TarefasApi.services;

var builder = WebApplication.CreateBuilder(args);
 


// Adiciona suporte a controllers (MVC)
builder.Services.AddControllers();



// Configura o DbContext com a string de conex�o
string? stringConnection = builder.Configuration.GetConnectionString("StringConexaoBanco");
if (stringConnection is null)
    throw new Exception("A string de conex�o definida � nula.");

builder.Services.AddDbContext<TarefasApiContext>(opt =>
    opt.UseSqlServer(stringConnection));

// Injeta reposit�rios e servi�os
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<TarefaRepository>();
builder.Services.AddScoped<TarefaService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
    cfg.AddProfile<MappingProfile>();

},typeof(MappingProfile).Assembly);

var app = builder.Build();

// Middleware padr�o
app.UseHttpsRedirection();

// Mapeia os controllers
app.MapControllers();

app.Run();
