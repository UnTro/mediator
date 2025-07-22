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
        
        readonly IPingHandler _pingHandler;
         
        public PingerControl(IMediator mediator, IPingHandler pingHandler)
        {
          
            _mediator = mediator;
            _pingHandler=pingHandler;
        }

        [HttpGet(Name = "qwerty")]
           
        public  IActionResult Get()
        {
            var ping = new Pinger() { Msg = "ok" };

            
            return Ok(_pingHandler.HandlePing(ping));
            //var input = new Pinger(){ Msg = "ping" };
            //var output = await _mediator.Send(new GenericPing<Pinger>
            //{

            //    Ping = input

            //});

        }

         

    }
    public interface IPingHandler {
        public string HandlePing(Pinger ping);
    }
    public class PingHandler : IPingHandler
    {
       public string HandlePing(Pinger ping)
        {
            return ping.Msg;
        }
    }
    public class AnalHandler : IPingHandler
    {
        public string HandlePing(Pinger ping)
        {
            return "ass";
        }
    }

}
