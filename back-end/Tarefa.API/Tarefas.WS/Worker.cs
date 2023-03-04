using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Tarefas.Core.Messages.Integration;

namespace Tarefas.WS
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //var factory = new ConnectionFactory { HostName = "localhost" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();

            //channel.QueueDeclare(queue: "adicionar-tarefa",
            //                     durable: false,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);

            //Console.WriteLine(" [*] Waiting for messages.");

            //var consumer = new EventingBasicConsumer(channel);

            //consumer.Received += (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine($" [x] Received {message}");
            //};

            //channel.BasicConsume(queue: "adicionar-tarefa",
            //                     autoAck: true,
            //                     consumer: consumer);

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        

    }
}