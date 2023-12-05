using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public interface IEstimateStrategy
    {
        Task<string> CheckState(Order order);     
        TripAssignedStatus State { get; }
    }
}
