using Microsoft.EntityFrameworkCore;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;
using OrderDelayAnnouncement.Domain.Models;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OMSContext _context;
        public OrderRepository(OMSContext context)
        {
            _context = context;
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _context.Orders.Include(x => x.DelayReports).Include(x => x.Trip)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public List<VendorAverage> GetStoreDelayReports()
        {
            var date = DateTime.Now.AddDays(-7);
            var result = _context.Orders
                .Where(x => x.DeliveredAt.HasValue && x.CreatedTime > date && x.DeliveredAt > x.DeliveredTime)
                .OrderByDescending(x => EF.Functions.DateDiffMinute(x.DeliveredTime, x.DeliveredAt))
                .GroupBy(c => c.VendorId).Select(c => new VendorAverage
                {
                    VendorId = c.Key,
                    DelayAverage = c.Average(o => EF.Functions.DateDiffMinute(o.DeliveredTime, o.DeliveredAt))
                }).ToList();

            return result;
        }

        public async Task<int> InsertAsync(Order order)
        {
            await _context.AddAsync(order);
             await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
