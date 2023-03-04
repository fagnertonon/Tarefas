using Tarefas.Core.Data;

namespace Tarefas.Data.Models
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<IEnumerable<StatusTarefa>> ObterStatus();

        Task<StatusTarefa> ObterStatus(string status);
    }
}