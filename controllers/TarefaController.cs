using Microsoft.AspNetCore.Mvc;
using TarefasApi.Dto;
using TarefasApi.models;
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

    [HttpPatch("{Id}")]
    public async Task<ActionResult<TarefasDto>> AtualizarStatusTarefaAsync(int Id, AtualizarStatusTarefaDto dto)
    {
        try
        {
            TarefasDto? atualizarStatus = await tarefaService.AtualizarStatusTarefaAsync(Id, dto);
            return Ok(atualizarStatus);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}

