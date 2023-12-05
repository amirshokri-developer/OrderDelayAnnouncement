using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class EstimateStrategyFactory : IEstimateStrategyFactory
    {
        private readonly IEstimateStrategy assigned;
        private readonly IEstimateStrategy notAssigned;

        public EstimateStrategyFactory(Func<TripAssignedStatus, IEstimateStrategy> serviceResolver)
        {
            assigned = serviceResolver(TripAssignedStatus.ASSIGNED);
            notAssigned = serviceResolver(TripAssignedStatus.NOT_ASSIGNED);
        }

        public IEstimateStrategy ChooseStrategy(Order order)
        {
            if (order.DelayState == TripAssignedStatus.ASSIGNED)
                return assigned;
            if (order.DelayState == TripAssignedStatus.NOT_ASSIGNED)
                return notAssigned;
            else
                throw new InvalidOperationException($"No supported strategy found for Delay State '{order.DelayState}'.");

        }
    }
}
