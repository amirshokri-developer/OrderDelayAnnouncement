namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface IDelayReportRepository
    {
        Task InsertAsync(DelayReport delay);
        Task<DelayReport> GetLast(int orderId);
        Task Update(DelayReport delay);
        Task<bool> CheckExistance(int agentId);
        Task<bool> CanAssign(int orderId);
    }

}
