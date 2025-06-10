using MediatR;
using MediatrStudying.Classes;
using Microsoft.AspNetCore.Mvc;

namespace MediatrStudying.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingerControl : ControllerBase
    {
        private readonly IMediator _mediator;

         
        public PingerControl(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "qwerty")]
           
        public async Task<IActionResult> Get()
        {
            var ping = await _mediator.Send(new GenericPing<Pinger> 
            { 
                Ping = new Pinger { Msg = "ping" } 
            });
            
            Console.WriteLine(ping.Msg);
            return Ok(ping);
        }
    }
}
