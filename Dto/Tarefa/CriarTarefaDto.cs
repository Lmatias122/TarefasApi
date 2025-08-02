using System.ComponentModel.DataAnnotations;
using TarefasApi.models;
using TarefasApi.Validation;

namespace TarefasApi.Dto
{
    public class CriarTarefaDto
    {
        public string Nome { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public Prioridade Prioridade { get; set; } = Prioridade.Baixa;

        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Prazo { get; set; } = DateTime.UtcNow.AddDays(7);

    }
}
