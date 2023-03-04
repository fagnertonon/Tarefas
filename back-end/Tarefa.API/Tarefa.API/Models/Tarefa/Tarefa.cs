using Tarefas.Core.DomainObjects;
using Tarefas.Core.Enumeradores;

namespace Tarefas.API.Models
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatus Status { get; set; }  

    }
}
