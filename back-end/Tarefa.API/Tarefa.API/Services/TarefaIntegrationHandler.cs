﻿//using MessageBus;
//using Tarefas.Core.Mediator;

//namespace Tarefas.API.Services
//{
//    public class TarefaIntegrationHandler : BackgroundService
//    {
//        private readonly IMessageBus _bus;
//        private readonly IServiceProvider _serviceProvider;

//        public TarefaIntegrationHandler(
//                            IServiceProvider serviceProvider,
//                            IMessageBus bus)
//        {
//            _serviceProvider = serviceProvider;
//            _bus = bus;
//        }

//        //private void SetResponder()
//        //{
//        //    _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
//        //        await RegistrarCliente(request));

//        //    _bus.AdvancedBus.Connected += OnConnect;
//        //}

//        protected override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            //SetResponder();
//            return Task.CompletedTask;
//        }

//        //private void OnConnect(object s, EventArgs e)
//        //{
//        //    SetResponder();
//        //}

//        //private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
//        //{
//        //    var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
//        //    ValidationResult sucesso;

//        //    using (var scope = _serviceProvider.CreateScope())
//        //    {
//        //        var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
//        //        sucesso = await mediator.EnviarComando(clienteCommand);
//        //    }

//        //    return new ResponseMessage(sucesso);
//        //}
//    }
//}
