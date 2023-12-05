namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<int> InsertAsync(Customer customer);
    }
}
