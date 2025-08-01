namespace TarefasApi.models;
public enum Prioridade
{
    Baixa,//0   
    Media,//1
    Alta //2
}
public class Tarefa
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public bool Concluida { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime? Prazo { get; set; }

    public Prioridade Prioridade { get; set; }

    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }
}