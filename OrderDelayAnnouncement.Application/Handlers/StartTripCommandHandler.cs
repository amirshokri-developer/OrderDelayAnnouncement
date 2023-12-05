using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class StartTripCommandHandler : IRequestHandler<StartTripCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public StartTripCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(StartTripCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
            {
                throw new ArgumentException("Order Not Found");
            }

            order.StartTrip();

            await _orderRepository.UpdateAsync(order);
        }
    }
}
