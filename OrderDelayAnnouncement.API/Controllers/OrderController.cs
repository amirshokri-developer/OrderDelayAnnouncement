using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Application.Models.Responses;
using OrderDelayAnnouncement.Application.Queries;

namespace OrderDelayAnnouncement.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) => _mediator = mediator;


        [HttpPost]
        public async Task<DelayResponse> ReportDelay([FromBody] ReportDelayCommand command)
        {
            return await _mediator.Send(command);            
        }

        [HttpPost]
        public async Task AssignToAgent([FromBody] AssignAgentCommand command)
        {
            await _mediator.Send(command);            
        }

        [HttpGet]
        public async Task<IEnumerable<VendorDelay>> GetVendorsWeeklyReport()
        {
            var result = await _mediator.Send(new GetWeeklyVendorDelaysQuery());
            return result.Delays;
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateOrderCommand command)
        {
           return await _mediator.Send(command);
        }


        [HttpPost]
        public async Task StartTrip([FromBody] StartTripCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
