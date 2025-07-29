using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TarefasApi.services;

namespace TarefasApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController (CategoriaService categoriaService)
{
    private readonly CategoriaService categoriaService = categoriaService;
   

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Listar()
    {
        List<Categoria> categorias = await categoriaService.ListarAsync();

        return categorias;
    } 
}

