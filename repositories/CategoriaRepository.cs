using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TarefasApi.data;
using TarefasApi.models;
namespace TarefasApi.repositories;

public class CategoriaRepository
{
    private readonly TarefasApiContext _context;
    public CategoriaRepository(TarefasApiContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        List<Categoria> retorno = await _context.Categorias.ToListAsync();

        return retorno;
    }

    public async Task<Categoria> IncluirAsync(Categoria categoria)
    {
        EntityEntry<Categoria> retorno = await _context.Categorias.AddAsync(categoria);

        await _context.SaveChangesAsync();

        return retorno.Entity;
    }

    public async Task AlterarAsync(int id, Categoria categoria)
    {
        Categoria? registroNoBanco = await ObterPorIdAsync(id);
        if (registroNoBanco == null)
        {
            throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
        }

        _context.Entry(registroNoBanco).CurrentValues.SetValues(categoria);

        await _context.SaveChangesAsync();

    }

    public async Task<Categoria?> ObterPorIdAsync(int id)
    {
        Categoria? categoria = await _context.Categorias.FindAsync(id);
        return categoria;
    }

    internal async Task ExcluirAsync(int id)
    {
        Categoria? categoria = await ObterPorIdAsync(id);
        if (categoria == null)
        {
            throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
        }
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}

