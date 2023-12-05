namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }

        ITripRepository TripRepository { get; }

        IDelayReportRepository DelayReportRepository { get; }

        Task Save();
    }
}
