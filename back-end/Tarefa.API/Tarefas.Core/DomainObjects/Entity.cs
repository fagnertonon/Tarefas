using System.Text.Json.Serialization;
using Tarefas.Core.Messages;

namespace Tarefas.Core.DomainObjects
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}