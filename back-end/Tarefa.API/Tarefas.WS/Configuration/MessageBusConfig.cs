using Tarefas.Core.Utils;
using Tarefas.MessageBus;
using Tarefas.WS.Services;

namespace Tarefas.WS.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<TarefaIntegrationHandler>();
        }
    }
}