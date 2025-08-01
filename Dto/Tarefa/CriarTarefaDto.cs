namespace TarefasApi.Dto
{
    public class CriarTarefaDto
    {
        public string Nome { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public int CategoriaId { get; set; }

    }
}
