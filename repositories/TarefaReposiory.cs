using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;
using TarefasApi.data;

namespace TarefasApi.repositories
{
    public class TarefaReposiory
    {
        private readonly TarefasApiContext _context;
        public TarefaReposiory(TarefasApiContext context)
        {
            _context = context;
        }
        public async Task<Tarefa> IncluirTarefaAsync(Tarefa tarefa)
        {
            EntityEntry<Tarefa> retorno = await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return retorno.Entity;
        }

        public async Task AlterarTarefasAsync(int id, Tarefa tarefa)
        {
            Tarefa? retornoTarefa = await ObterPorIdAsync(id);
            if (retornoTarefa == null)
            {
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");
            }

            _context.Entry(retornoTarefa).CurrentValues.SetValues(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa?> ObterPorIdAsync(int id)
        {
            Tarefa? tarefa = await _context.Tarefas.FindAsync(id);
            return tarefa;
        }

        public async Task<List<Tarefa>> ListarTarefasAsync() 
        {
            List<Tarefa> tarefas = await _context.Tarefas.ToListAsync();
            return tarefas;
        }

    }
}
