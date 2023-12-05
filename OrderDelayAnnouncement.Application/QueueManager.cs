using OrderDelayAnnouncement.Domain.Contracts;

namespace OrderDelayAnnouncement.Application
{
    public class QueueManager : IQueueManager
    {
        Queue<int> orderQueue = new Queue<int>();

        public void PushToQueue(int orderId)
        {
            if(!orderQueue.Contains(orderId))
            {
                orderQueue.Enqueue(orderId);
            }            
        }

        public int PeekFromQueue()
        {
            return orderQueue.Peek();
        }

        public int PopFromQueue()
        {            
            return orderQueue.Dequeue();
            
        }
    }

}
