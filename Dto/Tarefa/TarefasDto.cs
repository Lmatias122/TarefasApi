using System.Diagnostics.CodeAnalysis;
using TarefasApi.Dto.Categoria;

namespace TarefasApi.Dto
{
    public class TarefasDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public CategoriasDto Categoria { get; set; } 
    }
}
