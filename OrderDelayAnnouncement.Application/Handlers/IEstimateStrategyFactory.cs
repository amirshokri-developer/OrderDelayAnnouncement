using OrderDelayAnnouncement.Domain;

namespace OrderDelayAnnouncement.Application.Handlers
{
    public interface IEstimateStrategyFactory
    {
        IEstimateStrategy ChooseStrategy(Order order);
    }
}
