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
        List<Categoria> retorno = await categoriaService.ListarAsync();

        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> IncluirAsync([FromBody] Categoria categoria)
    {
        Categoria retorno = await categoriaService.IncluirAsync(categoria);
        return retorno;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Categoria>> ObterPorID(int Id)
    {
        try
        {
            Categoria retorno = await categoriaService.ObterPorIDAsync(Id);
            return Ok(retorno);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> AlterarAsync(int id, [FromBody] Categoria categoria)
    {
        try
        {
            await categoriaService.AlterarAsync(id, categoria);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> ExcluirAsync(int id)
    {
        try
        {
            await categoriaService.ExcluirAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}

