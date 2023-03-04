using FluentValidation.Results;
using MediatR;
using Tarefas.Core.Messages;
using Tarefas.Data.Models;
using Tarefas.MessageBus;
using Tarefas.Core.Messages.Integration;

namespace Tarefas.API.Application
{
    public class TarefaCommandHandler : CommandHandler,
        IRequestHandler<RegistrarTarefaCommand, ValidationResult>,
        IRequestHandler<AtualizarTarefaCommand, ValidationResult>,
        IRequestHandler<ExcluirTarefaCommand, ValidationResult>,
        IRequestHandler<ConcluirTarefaCommand, ValidationResult>,
        IRequestHandler<DesenvolverTarefaCommand, ValidationResult>
    {
        private readonly ITarefaRepository _TarefaRepository;
        private readonly IMessageBus _bus;

        public TarefaCommandHandler(ITarefaRepository TarefaRepository, IMessageBus bus, IConfiguration configuration)
        {
            _TarefaRepository = TarefaRepository;
            _bus = bus;
        }

        public async Task<ValidationResult> Handle(RegistrarTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var adicionarTarefaIntegrationEvent = new AdicionarTarefaIntegrationEvent(request.Descricao, request.DataPrevisao, request.StatusId);

            try
            {
                var responseMessage = await _bus.RequestAsync<AdicionarTarefaIntegrationEvent, ResponseMessage>(adicionarTarefaIntegrationEvent);
                return responseMessage.ValidationResult;
            }
            catch
            {
                AdicionarErro($"Ocorreu um erro ao adicionar a tarefa: {request.Descricao}");
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var Tarefa = await _TarefaRepository.ObterPorId(request.Id);

            if (Tarefa == null)
            {
                AdicionarErro("Tarefa não encontrada");
                return ValidationResult;
            }

            try
            {
                var atualizarTarefaIntegrationEvent = new AtualizarTarefaIntegrationEvent(request.Id, request.Descricao, request.DataPrevisao, request.StatusId);

                var responseMessage = await _bus.RequestAsync<AtualizarTarefaIntegrationEvent, ResponseMessage>(atualizarTarefaIntegrationEvent);
                return responseMessage.ValidationResult;
            }
            catch
            {
                AdicionarErro($"Ocorreu um erro ao atualizar a tarefa: {request.Descricao}");
            }

            return ValidationResult;
        }


        public async Task<ValidationResult> Handle(ExcluirTarefaCommand request, CancellationToken cancellationToken)
        {
            var Tarefa = await _TarefaRepository.ObterPorId(request.Id);

            if (Tarefa == null)
            {
                AdicionarErro("Tarefa não encontrada");
                return ValidationResult;
            }

            try
            {
                var excluirTarefaIntegrationEvent = new ExcluirTarefaIntegrationEvent(request.Id);

                var responseMessage = await _bus.RequestAsync<ExcluirTarefaIntegrationEvent, ResponseMessage>(excluirTarefaIntegrationEvent);
                return responseMessage.ValidationResult;
            }
            catch
            {
                AdicionarErro($"Ocorreu um erro ao excluir a tarefa: {request.Descricao}");
            }

            return ValidationResult;
        }
        public async Task<ValidationResult> Handle(ConcluirTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var Tarefa = await _TarefaRepository.ObterPorId(request.Id);

            if (Tarefa == null)
            {
                AdicionarErro("Tarefa não encontrada");
                return ValidationResult;
            }
            var statusConcluido = await _TarefaRepository.ObterStatus("Concluído");

            if (Tarefa.Status == statusConcluido)
            {
                AdicionarErro("Tarefa já concluida anteriormente");
                return ValidationResult;
            }

            var concluirTarefaIntegrationEvent = new ConcluirTarefaIntegrationEvent(request.Id);

            await _bus.PublishAsync<ConcluirTarefaIntegrationEvent>(concluirTarefaIntegrationEvent);

            return ValidationResult;
        }
        public async Task<ValidationResult> Handle(DesenvolverTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var Tarefa = await _TarefaRepository.ObterPorId(request.Id);

            if (Tarefa == null)
            {
                AdicionarErro("Tarefa não encontrada");
                return ValidationResult;
            }
            var statusConcluido = await _TarefaRepository.ObterStatus("Em Desenvolvimento");

            if (Tarefa.Status == statusConcluido)
            {
                AdicionarErro("Tarefa já Em desenvolvimento ");
                return ValidationResult;
            }

            var desenvolverTarefaIntegrationEvent = new DesenvolverTarefaIntegrationEvent(request.Id);

            await _bus.PublishAsync<DesenvolverTarefaIntegrationEvent>(desenvolverTarefaIntegrationEvent);

            return ValidationResult;
        }
    }
}