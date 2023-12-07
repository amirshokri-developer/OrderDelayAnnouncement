namespace OrderDelayAnnouncement.Domain
{
    public class DelayReport
    {
        public int Id { get; private set; }

        public int OrderId { get; private set; }

        public int? AgentId { get; private set; }

        public DateTime DelayTime { get; private set; }

        public DelayReportStatus Status { get; private set; }

        public Order Order { get; private set; }

        public Agent? Agent { get; set; }

        public double DelayMin => (DelayTime - Order.DeliveredTime).TotalMinutes; 
        private DelayReport()
        {

        }

        private DelayReport(int orderId)
        {
            OrderId = orderId;
            Status = DelayReportStatus.PENDING;
            DelayTime = DateTime.Now;
        }

        public static DelayReport Create(int orderId)
        {
            return new DelayReport(orderId);
        }

        public void AssignAgent(int agentId)
        {
            AgentId = agentId;
        }
    }
}