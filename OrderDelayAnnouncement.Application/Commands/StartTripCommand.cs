using MediatR;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class StartTripCommand : IRequest
    {
        public int OrderId { get; set; }
    }

}
