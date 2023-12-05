using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public class NotAssignedTripStrategy : IEstimateStrategy
    {
        public TripAssignedStatus State => TripAssignedStatus.NOT_ASSIGNED;
        private readonly IQueueManager _queueManager;  
        

        public NotAssignedTripStrategy(IQueueManager queueManager)
        {
            _queueManager = queueManager;
        }

        public async Task<string> CheckState(Order order)
        {
            if (order.CanPushToQueue) {
                return "Already Has Agent";
            }

            _queueManager.PushToQueue(order.Id);
            return "Add To Queue";
        }
    }
}
