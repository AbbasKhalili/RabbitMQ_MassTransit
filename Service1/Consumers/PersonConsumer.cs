using System.Threading.Tasks;
using MassTransit;
using Shared;

namespace Service1.Consumers
{
    public class PersonConsumer : IConsumer<Person>
    {
        public async Task Consume(ConsumeContext<Person> context)
        {
            var data = context.Message;
        }
    }
}