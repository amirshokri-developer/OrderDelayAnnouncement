using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDelayAnnouncement.Application.Commands;

namespace OrderDelayAnnouncement.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<int> Create([FromBody] CreateAgentCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
