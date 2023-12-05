using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDelayAnnouncement.Application.Commands;

namespace OrderDelayAnnouncement.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<int> Create([FromBody] CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
