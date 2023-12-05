using MediatR;
using OrderDelayAnnouncement.Application.Models.Responses;
using OrderDelayAnnouncement.Application.Queries;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class GetWeeklyVendorDelaysQueryHandler : IRequestHandler<GetWeeklyVendorDelaysQuery, GetWeeklyVendorDelaysResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetWeeklyVendorDelaysQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetWeeklyVendorDelaysResponse> Handle(GetWeeklyVendorDelaysQuery request,
            CancellationToken cancellationToken)
        {
            var result = _orderRepository.GetStoreDelayReports();

            var data = result.Select(x => new VendorDelay()
            {
                AverageDelay = x.DelayAverage.HasValue ? (int)x.DelayAverage.Value : 0,
                VendorId = x.VendorId
            }).ToList();

            return new GetWeeklyVendorDelaysResponse
            {
                Delays = data
            };
        }

    }
}
