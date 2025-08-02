using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using TarefasApi.repositories;
using TarefasApi.models;

namespace TarefasApi.services;

public class CategoriaService
{
    private readonly CategoriaRepository _categoriaRepository;
    public CategoriaService(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        List<Categoria> retorno = await _categoriaRepository.ListarAsync();

        return retorno;
    }

    public async Task<Categoria> IncluirAsync(Categoria categoria)
    {
        Categoria retorno = await _categoriaRepository.IncluirAsync(categoria);

        return retorno;
    }

    public async Task AlterarAsync(int id, Categoria categoria)
    {
        await _categoriaRepository.AlterarAsync(id, categoria);
    }

    public async Task ExcluirAsync(int id)
    {
        await _categoriaRepository.ExcluirAsync(id);
    }

    public async Task<Categoria> ObterPorIDAsync(int id)
    {
        Categoria? retorno = await _categoriaRepository.ObterPorIdAsync(id);
        if (retorno is null)
        {
            throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
        }
        return retorno;
    }
}

