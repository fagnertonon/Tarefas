using Tarefas.Core.DomainObjects;

namespace Tarefas.Data.Models
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string Descricao { get; set; }
        public DateTime DataPrevisao { get; set; }
        public DateTime? DataTermino { get; set; }

        public Guid StatusId { get; set; }
        public StatusTarefa Status { get; set; }  
    }
}
