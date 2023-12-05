namespace OrderDelayAnnouncement.Domain.Tests.Unit
{
    public class OrderTestBuilder
    {
        public OrderTestBuilder()
        {        
        }

        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public int VendorId { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime DeliveredTime { get; private set; }
        public DateTime? DeliveredAt { get; private set; }


        public OrderTestBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }
        
        public OrderTestBuilder WithCustomer(int customerId)
        {
            this.CustomerId = customerId;
            return this;
        }

        public OrderTestBuilder WithVendor(int vendorId)
        {
            this.VendorId = vendorId;
            return this;
        }

        public OrderTestBuilder WithCreatedTime(DateTime createdTime)
        {
            this.CreatedTime = createdTime;
            return this;
        }


        public OrderTestBuilder WithDeliveredTime(DateTime deliveredTime)
        {
            this.DeliveredTime = deliveredTime;
            return this;
        }

        public OrderTestBuilder WithDeliveredAt(DateTime deliveredAt)
        {
            this.DeliveredAt = deliveredAt;
            return this;
        }
        public Order Build()
        {
            return Order.Create(
                VendorId,
                CustomerId,
                DeliveredTime);
        }
    }

}