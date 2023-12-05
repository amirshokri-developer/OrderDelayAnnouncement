namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface IAgentRepository
    {
        Task<Agent> GetAsync(int id);

        Task<int> InsertAsync(Agent agent);
    }
}
