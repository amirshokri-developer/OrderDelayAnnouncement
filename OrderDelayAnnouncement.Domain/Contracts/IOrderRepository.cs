using OrderDelayAnnouncement.Domain.Models;

namespace OrderDelayAnnouncement.Domain.Contracts
{

    public interface IOrderRepository
    {            
        Task<Order> GetAsync(int id);
        List<VendorAverage> GetStoreDelayReports();
        Task<int> InsertAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
