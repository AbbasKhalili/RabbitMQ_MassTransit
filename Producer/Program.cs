using System;
using System.Threading.Tasks;
using MassTransit;
using Shared;

namespace Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Producer";



            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host("rabbitmq://localhost");

                sbc.ReceiveEndpoint("Consumer_queue", ep =>
                {
                    ep.Handler<Person>(context => Console.Out.WriteLineAsync($"Received: {context.Message}"));
                });
            });

            await bus.StartAsync();

            await bus.Publish(new Person { Id = Guid.NewGuid(), FirstName = "Joe", LastName = "Cool", Age = new Random().Next(1, 255) });

            //await bus.StopAsync();

            Console.ReadLine();
        }
    }
}
