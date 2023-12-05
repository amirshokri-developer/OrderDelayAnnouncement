using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class AssignedTripStrategy : IEstimateStrategy
    {
        public TripAssignedStatus State => TripAssignedStatus.ASSIGNED;
        private readonly ITripEstimateService _service;

        public AssignedTripStrategy(ITripEstimateService service)
        {
            _service = service;
        }

        public async Task<string> CheckState(Order order)
        {
            var estimate = await _service.GetEstimate();

            return $"Estimate is {estimate}";
        }
    }
}
