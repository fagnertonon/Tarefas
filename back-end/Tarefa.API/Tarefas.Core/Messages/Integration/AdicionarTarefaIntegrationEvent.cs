using System;

namespace Tarefas.Core.Messages.Integration
{
    public class AdicionarTarefaIntegrationEvent : IntegrationEvent
    {
        public string? Descricao { get; set; }
        public DateTime DataPrevisao { get; set; }
        public Guid StatusId { get; set; }

        public AdicionarTarefaIntegrationEvent(string? descricao, DateTime data, Guid statusId)
        {
            Descricao = descricao;
            DataPrevisao = data;
            StatusId = statusId;
        }
    }

    public class AtualizarTarefaIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataPrevisao { get; set; }
        public Guid StatusId { get; set; }

        public AtualizarTarefaIntegrationEvent(Guid id,string? descricao, DateTime data, Guid statusId)
        {
            Id = id;
            Descricao = descricao;
            DataPrevisao = data;
            StatusId = statusId;
        }
    }

    public class ExcluirTarefaIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }

        public ExcluirTarefaIntegrationEvent(Guid id)
        {
            Id = id;
        }
    }

    public class ConcluirTarefaIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }

        public ConcluirTarefaIntegrationEvent(Guid id)
        {
            Id = id;
        }
    }
    public class DesenvolverTarefaIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }

        public DesenvolverTarefaIntegrationEvent(Guid id)
        {
            Id = id;
        }
    }
}