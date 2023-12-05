using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly OMSContext _context;
        public VendorRepository(OMSContext context)
        {
            _context = context;
        }


        public async Task<int> InsertAsync(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
            await _context.SaveChangesAsync();
            return vendor.Id;
        }
    }
}
