using Microsoft.EntityFrameworkCore;
using OrderDelayAnnouncement.Domain;
using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Infrastructure.Persistance.Repositories
{
    public class DelayReportRepository : IDelayReportRepository
    {
        private readonly OMSContext _context;
        public DelayReportRepository(OMSContext context)
        {
            _context = context;
        }

        public async Task<DelayReport> GetLast(int orderId)
        {
            return _context.DelayReports.Where(x => x.OrderId == orderId)
                .OrderByDescending(x => x.DelayTime).FirstOrDefault();
        }

        public async Task<bool> CanAssign(int orderId)
        {
            return await _context.DelayReports.AnyAsync(x => x.OrderId == orderId &&
                    x.AgentId.HasValue && x.Status == DelayReportStatus.PENDING);               
        }

        public async Task Update(DelayReport delay)
        {            
            _context.Update(delay);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistance(int agentId)
        {
            return await _context.DelayReports
                .AnyAsync(x => x.AgentId == agentId && x.Status == DelayReportStatus.PENDING);
        }

        public async Task InsertAsync(DelayReport delay)
        {
            await _context.DelayReports.AddAsync(delay);
            await _context.SaveChangesAsync();
        }

    }
}
