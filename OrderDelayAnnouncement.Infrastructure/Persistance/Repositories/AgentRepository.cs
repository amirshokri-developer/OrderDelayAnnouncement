using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly OMSContext _context;
        public AgentRepository(OMSContext context)
        {
            _context = context;
        }

        public async Task<Agent> GetAsync(int id)
        {
            return await _context.Agents.FindAsync(id);
        }

        public async Task<int> InsertAsync(Agent agent)
        {
            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();
            return agent.Id;
        }
    }
}
