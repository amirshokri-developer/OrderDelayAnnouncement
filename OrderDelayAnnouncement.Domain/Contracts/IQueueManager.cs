namespace OrderDelayAnnouncement.Domain.Contracts
{
    public interface IQueueManager
    {
        void PushToQueue(int orderId);
        int PeekFromQueue();
        int PopFromQueue();
    }
}
