using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Service1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IBus _bus;
        public PersonController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            if (person == null) return BadRequest();
            
            var uri = new Uri("rabbitmq://localhost/PersonQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(person);
            return Ok();
        }
    }
}
