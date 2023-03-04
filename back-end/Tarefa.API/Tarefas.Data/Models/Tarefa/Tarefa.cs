using Tarefas.Core.DomainObjects;

namespace Tarefas.Data.Models
{
    public class StatusTarefa : Entity
    {
        public string Descricao { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
