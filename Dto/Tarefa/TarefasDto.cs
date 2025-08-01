using System.Diagnostics.CodeAnalysis;

namespace TarefasApi.Dto
{
    public class TarefasDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
