using Microsoft.AspNetCore.Mvc;
using TarefasApi.services;

namespace TarefasApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController(TarefaService tarefaService) : ControllerBase
{
    private readonly TarefaService tarefaService = tarefaService;

    [HttpPost]
    public async Task<ActionResult<Tarefa>> IncluirTarefaAsync([FromBody] Tarefa tarefa)
    {
        Tarefa retorno = await tarefaService.IncluirTarefaAsync(tarefa);
        return Ok(retorno);
    }
}

