namespace TarefasApi.Dto
{
    public class AtualizaTarefaDto
    {
        public string Nome { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public int CategoriaId { get; set; }
    }
}
