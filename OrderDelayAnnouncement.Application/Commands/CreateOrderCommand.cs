using MediatR;

namespace OrderDelayAnnouncement.Application.Commands
{
    public sealed class CreateOrderCommand : IRequest<int>
    {
        public int VendorId { get; set; }

        public int CustomerId { get; set; }

        public int DeliveredMinutes { get; set; }

        public int? DeliveredAtMiniutes { get; set; }
    }

}
