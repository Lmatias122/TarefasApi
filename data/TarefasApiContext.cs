using Microsoft.EntityFrameworkCore;

namespace TarefasApi.data
{
    public class TarefasApiContext : DbContext
    {
        public TarefasApiContext(DbContextOptions<TarefasApiContext> dbContextOptions): base(dbContextOptions)
        {        
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
