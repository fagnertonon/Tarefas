using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarefas.Core.Mediator;
using Tarefas.Data;
using Tarefas.Data.Models;
using Tarefas.Data.Repository;
using Tarefas.WS.Configuration;
using Tarefas.WS.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddMediatR(typeof(Program));

        services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        services.AddScoped<ApplicationContext>();

        services.AddHostedService<TarefaIntegrationHandler>(); 

        services.AddMessageBusConfiguration(configuration);
    })
    .Build();

await host.RunAsync();
