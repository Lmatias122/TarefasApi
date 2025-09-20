using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TarefasApi.Dto;
using TarefasApi.models;
using TarefasApi.services;

namespace TarefasApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController(TarefaService tarefaService, IMapper _mapper) : ControllerBase
{
    private readonly TarefaService tarefaService = tarefaService;
    private readonly IMapper _mapper = _mapper;

    [HttpPost]
    public async Task<ActionResult<TarefasDto>> CriarTarefaAsync([FromBody] CriarTarefaDto dto)
    {
        var tarefa = _mapper.Map<Tarefa>(dto);
        var tarefaCriada = await tarefaService.CriarTarefaAsync(tarefa);
        return CreatedAtAction(nameof(DetalharTarefaPorId), new { id = tarefaCriada.Id }, tarefaCriada);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefasDto>> DetalharTarefaPorId(int id)
    {
        var tarefa = await tarefaService.BuscarTarefaPorIdAsync(id);

        if (tarefa == null)
            return NotFound(new { mensagem = "Tarefa não encontrada." });

        return Ok(tarefa);
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

    [HttpGet]
    public async Task<ActionResult<List<TarefasDto>>> ListarTarefasAsync()
    {
        var tarefasDto = await tarefaService.ListarTarefasAsync();
        return Ok(tarefasDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaTarefaAsync(int id)
    {
        try
        {
            await tarefaService.DeletaTarefaAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensagem = ex.Message });
        }
    }
}

