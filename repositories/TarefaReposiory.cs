using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;
using TarefasApi.data;
using TarefasApi.Dto;
using TarefasApi.models;

namespace TarefasApi.repositories
{
    public class TarefaReposiory
    {
        private readonly TarefasApiContext _context;
        private readonly IMapper _mapper;
        public TarefaReposiory(TarefasApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Tarefa> IncluirTarefaAsync(Tarefa tarefa)
        {
            EntityEntry<Tarefa> retorno = await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return retorno.Entity;
        }

        public async Task AlterarTarefasAsync(int id, Tarefa tarefa)
        {
            Tarefa? retornoTarefa = await _context.Tarefas.FindAsync(id);
            if (retornoTarefa == null)
            {
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");
            }

            _context.Entry(retornoTarefa).CurrentValues.SetValues(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<TarefasDto?> AtualizarStatusTarefaAsync(int id, AtualizarStatusTarefaDto dto)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");
            }
            tarefa.Concluida = dto.Concluida;
            await _context.SaveChangesAsync();
            var tarefaDto = _mapper.Map<TarefasDto>(tarefa);
            return tarefaDto;

        }

        public async Task<List<Tarefa>> ListarTarefasAsync() 
        {
            List<Tarefa> tarefas = await _context.Tarefas.ToListAsync();
            return tarefas;
        }

    }
}
