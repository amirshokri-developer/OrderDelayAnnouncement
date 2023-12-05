using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly OMSContext _context;
        public TripRepository(OMSContext context)
        {
            context = _context;
        }
    }
}
