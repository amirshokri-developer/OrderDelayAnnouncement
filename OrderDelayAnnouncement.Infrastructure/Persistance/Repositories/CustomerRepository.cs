using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OMSContext _context;
        public CustomerRepository(OMSContext context)
        {
            _context = context;
        }

        public async Task<int> InsertAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}
