using AutoMapper;
using TarefasApi.Dto;
using TarefasApi.models;
using TarefasApi.repositories;

namespace TarefasApi.services;

public class TarefaService
{
    private readonly TarefaReposiory _tarefaRepository;

    private readonly CategoriaRepository _categoriaRepository;

    private readonly IMapper _mapper;
    public TarefaService(TarefaReposiory tarefaRepository, CategoriaRepository categoriaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
       _categoriaRepository = categoriaRepository; 
       _mapper = mapper;
    }
    public async Task <TarefasDto> CriarTarefaAsync(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Nome))
            throw new Exception("O nome da tarefa não pode estar vazio.");

        var categoria = await _categoriaRepository.ObterPorIdAsync(tarefa.CategoriaId);
        
        if (categoria == null)
        {
            throw new KeyNotFoundException($"Categoria com ID {tarefa.CategoriaId} não encontrada.");
        }
        tarefa.DataCriacao = DateTime.UtcNow;
        tarefa.Categoria = categoria; // Associa a categoria à tarefa
        await _tarefaRepository.CriarTarefaAsync(tarefa);

        return _mapper.Map<TarefasDto>(tarefa);
    }

    public async Task<TarefasDto?> BuscarTarefaPorIdAsync(int id)
    {
        var tarefa = await _tarefaRepository.ObterPorIdAsync(id);

        if (tarefa == null)
            return null;

        var tarefaDto = _mapper.Map<TarefasDto>(tarefa);
        return tarefaDto;
    }
    public async Task<TarefasDto?> AtualizarStatusTarefaAsync(int id, AtualizarStatusTarefaDto dto)
    {
        TarefasDto tarefaDto = await _tarefaRepository.AtualizarStatusTarefaAsync(id, dto);
        return tarefaDto;
    }

    public async Task<List<TarefasDto>> ListarTarefasAsync()
    {
        var tarefas = await _tarefaRepository.ListarTarefasAsync();
        return tarefas;
    }
}

