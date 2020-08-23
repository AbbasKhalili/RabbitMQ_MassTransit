using System;
using System.Threading.Tasks;
using MassTransit;
using Shared;

namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Consumer";

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host("rabbitmq://localhost");

                sbc.ReceiveEndpoint("Producer_queue", ep =>
                {
                    ep.Handler<Person>(context => Console.Out.WriteLineAsync($"Received: {context.Message}"));
                });
            });

            await bus.StartAsync();

            //await bus.Publish(new Person { Id = Guid.NewGuid(), FirstName = "Andro", LastName = "Pirlo", Age = new Random().Next(1, 255) });

            //await bus.StopAsync();

            Console.ReadLine();
        }
    }
}
