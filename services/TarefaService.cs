using TarefasApi.Dto;
using TarefasApi.models;
using TarefasApi.repositories;

namespace TarefasApi.services;

public class TarefaService
{
    private readonly TarefaReposiory _tarefaRepository;
    public TarefaService(TarefaReposiory tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }
    public async Task<Tarefa> IncluirTarefaAsync(Tarefa tarefa)
    {
        Tarefa retorno = await _tarefaRepository.IncluirTarefaAsync(tarefa);
        return retorno;
    }

    public async Task<TarefasDto?> AtualizarStatusTarefaAsync(int id, AtualizarStatusTarefaDto dto)
    {
        TarefasDto tarefaDto = await _tarefaRepository.AtualizarStatusTarefaAsync(id, dto);
        return tarefaDto;
    }
}

