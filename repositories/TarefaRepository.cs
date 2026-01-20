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
    public class TarefaRepository
    {
        private readonly TarefasApiContext _context;
        private readonly IMapper _mapper;
        public TarefaRepository(TarefasApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CriarTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }
        public async Task<Tarefa?> ObterPorIdAsync(int id)
        {
            return await _context.Tarefas
                .Include(t => t.Categoria) // opcional: se quiser incluir categoria
                .FirstOrDefaultAsync(t => t.Id == id);
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

        public async Task<List<TarefasDto>> ListarTarefasAsync()
        {
            List<Tarefa> tarefas = await _context
                .Tarefas
                .Include(t => t.Categoria)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<TarefasDto>>(tarefas);
        }

        public async Task DeletaTarefaAsync(int id) 
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null){
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");
            }
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

    }

}

