using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TarefasApi.data;

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
}

