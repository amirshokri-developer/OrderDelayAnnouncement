using MediatR;
using OrderDelayAnnouncement.Application.Commands;
using OrderDelayAnnouncement.Application.Models.Responses;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class ReportDelayCommandHandler : IRequestHandler<ReportDelayCommand, DelayResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDelayReportRepository _delayRepository;
        private readonly IEstimateStrategyFactory _factory;
        public ReportDelayCommandHandler(IOrderRepository orderRepository,            
            IDelayReportRepository delayRepository,            
            IEstimateStrategyFactory factory)
        {
            _orderRepository = orderRepository;            
            _delayRepository = delayRepository;            
            _factory = factory;
        }

        public async Task<DelayResponse> Handle(ReportDelayCommand request, 
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                throw new ArgumentException("Order Not Found");

            if (!order.CanReportDelay)            
                throw new ArgumentException("Can Not Report Delay");
            

            var strategy = _factory.ChooseStrategy(order);

            string message = await strategy.CheckState(order);
            
            await _delayRepository.InsertAsync(order.Report());

            return new DelayResponse
            {
                Message = message
            };
            
        }
    }
}
