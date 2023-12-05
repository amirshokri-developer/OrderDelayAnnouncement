namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface IVendorRepository
    {
        Task<int> InsertAsync(Vendor vendor);
    }
}
