using FluentValidation.Results;
using MediatR;
using Tarefas.API.Application;
using Tarefas.Core.Mediator;
using Tarefas.Data.Models;
using Tarefas.Data;
using Tarefas.Data.Repository;

namespace Tarefas.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegistrarTarefaCommand, ValidationResult>, TarefaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarTarefaCommand, ValidationResult>, TarefaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirTarefaCommand, ValidationResult>, TarefaCommandHandler>();


            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<ApplicationContext>();
        }
    }
}