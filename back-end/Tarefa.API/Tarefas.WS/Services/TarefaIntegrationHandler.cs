using FluentValidation.Results;
using Tarefas.MessageBus;
using Tarefas.Core.Data;
using Tarefas.Core.Messages.Integration;
using Tarefas.Data.Models;

namespace Tarefas.WS.Services
{
    public class TarefaIntegrationHandler : IHostedService, IDisposable
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        protected ValidationResult ValidationResult;

        public TarefaIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
            ValidationResult = new ValidationResult();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            SetSubscribers();
            SetResponder();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromCanceled(cancellationToken);
        }
        private void SetResponder()
        {
            _bus.RespondAsync<AdicionarTarefaIntegrationEvent, ResponseMessage>(async request =>
                await AdicionarTarefa(request));

            _bus.RespondAsync<AtualizarTarefaIntegrationEvent, ResponseMessage>(async request =>
               await AtualizarTarefa(request));

            _bus.RespondAsync<ExcluirTarefaIntegrationEvent, ResponseMessage>(async request =>
               await ExcluirTarefa(request));
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<ConcluirTarefaIntegrationEvent>("ConcluirTarefa", async request =>
              await ConcluirTarefa(request));

            _bus.SubscribeAsync<DesenvolverTarefaIntegrationEvent>("DesenvolverTarefa", async request =>
              await DesenvolerTarefa(request));
        }

        private async Task<ResponseMessage> AdicionarTarefa(AdicionarTarefaIntegrationEvent message)
        {
            ValidationResult sucesso;

            var tarefa = new Tarefa
            {
                Descricao = message.Descricao,
                DataPrevisao = message.DataPrevisao,
                StatusId = message.StatusId,
            };

            using (var scope = _serviceProvider.CreateScope())
            {
                var _tarefaRepository = scope.ServiceProvider.GetRequiredService<ITarefaRepository>();

                _tarefaRepository.Adicionar(tarefa);

                sucesso = await PersistirDados(_tarefaRepository.UnitOfWork);
            }

            return new ResponseMessage(sucesso);
        }

        private async Task<ResponseMessage> AtualizarTarefa(AtualizarTarefaIntegrationEvent message)
        {
            ValidationResult sucesso;

            var tarefa = new Tarefa
            {
                Id = message.Id,
                Descricao = message.Descricao,
                DataPrevisao = message.DataPrevisao,
                StatusId = message.StatusId,
            };

            using (var scope = _serviceProvider.CreateScope())
            {
                var _tarefaRepository = scope.ServiceProvider.GetRequiredService<ITarefaRepository>();

                _tarefaRepository.Atualizar(tarefa);

                sucesso = await PersistirDados(_tarefaRepository.UnitOfWork);
            }

            return new ResponseMessage(sucesso);
        }

        private async Task<ResponseMessage> ExcluirTarefa(ExcluirTarefaIntegrationEvent message)
        {
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var _tarefaRepository = scope.ServiceProvider.GetRequiredService<ITarefaRepository>();

                var tarefa = await _tarefaRepository.ObterPorId(message.Id);

                _tarefaRepository.Excluir(tarefa);

                sucesso = await PersistirDados(_tarefaRepository.UnitOfWork);
            }

            return new ResponseMessage(sucesso);
        }

        private async Task ConcluirTarefa(ConcluirTarefaIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _tarefaRepository = scope.ServiceProvider.GetRequiredService<ITarefaRepository>();

                var tarefa = await _tarefaRepository.ObterPorId(message.Id);

                var status = await _tarefaRepository.ObterStatus("Concluído");

                tarefa.Status = status;
                tarefa.DataTermino = DateTime.Now;

                _tarefaRepository.Atualizar(tarefa);

                await PersistirDados(_tarefaRepository.UnitOfWork);
            }
        }
        private async Task DesenvolerTarefa(DesenvolverTarefaIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _tarefaRepository = scope.ServiceProvider.GetRequiredService<ITarefaRepository>();

                var tarefa = await _tarefaRepository.ObterPorId(message.Id);

                var status= await _tarefaRepository.ObterStatus("Em Desenvolvimento");

                tarefa.Status = status;

                _tarefaRepository.Atualizar(tarefa);

                await PersistirDados(_tarefaRepository.UnitOfWork);
            }
        }
        public void Dispose()
        {
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
