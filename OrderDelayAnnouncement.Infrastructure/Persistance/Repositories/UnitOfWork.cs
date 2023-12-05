using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OMSContext _context;
        private OrderRepository _orderRepo;
        private TripRepository _tripRepo;
        private DelayReportRepository _delayRepo;
        public UnitOfWork(OMSContext context)
        {
            _context = context;
        }

        public IOrderRepository OrderRepository
        {
            get
            {

                if (_orderRepo == null)
                {
                    _orderRepo = new OrderRepository(_context);
                }
                return _orderRepo;
            }
        }

        public ITripRepository TripRepository
        {
            get
            {

                if (_tripRepo == null)
                {
                    _tripRepo = new TripRepository(_context);
                }
                return _tripRepo;
            }
        }

        public IDelayReportRepository DelayReportRepository
        {
            get
            {

                if (_delayRepo == null)
                {
                    _delayRepo = new DelayReportRepository(_context);
                }
                return _delayRepo;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
