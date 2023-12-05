using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var deliveredDate = DateTime.Now.AddMinutes(request.DeliveredMinutes);
            var order = Order.Create(request.VendorId, request.CustomerId, deliveredDate);
            if (request.DeliveredAtMiniutes.HasValue)
            {
                order.CreateDeliveredTrip();
                var deliveredAt = DateTime.Now.AddMinutes(request.DeliveredAtMiniutes.Value);
                order.SetDeliveredAt(deliveredAt);                
            }

            var id = await _orderRepository.InsertAsync(order);
            return id;
        }
    }
}
