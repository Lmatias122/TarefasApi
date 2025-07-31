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
}

