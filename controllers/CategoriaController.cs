using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TarefasApi.services;

namespace TarefasApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(CategoriaService categoriaService) : ControllerBase
{
    private readonly CategoriaService categoriaService = categoriaService;


    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Listar()
    {
        List<Categoria> categorias = await categoriaService.ListarAsync();

        return categorias;
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> IncluirAsync([FromBody] Categoria categoria)
    {
        Categoria retorno = await categoriaService.IncluirAsync(categoria);
        return retorno;
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
    {
        await categoriaService.AlterarAsync(id, categoria);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> ExcluirAsync(int id)
    {
        await categoriaService.ExcluirAsync(id);
        return NoContent();
    }
}

