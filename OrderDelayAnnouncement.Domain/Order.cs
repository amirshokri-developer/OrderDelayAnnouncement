using OrderDelayAnnouncement.Domain.Exceptions;

namespace OrderDelayAnnouncement.Domain
{
    public class Order
    {
        public int Id { get; private set; }

        public int VendorId { get; private set; }

        public int CustomerId { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime DeliveredTime { get; private set; }

        public DateTime? DeliveredAt { get; private set; }

        public Vendor Vendor { get; private set; }

        public Customer Customer { get; private set; }

        public Trip? Trip { get; set; }

        public List<DelayReport> DelayReports { get; } = new List<DelayReport>();

        public bool CanReportDelay => DeliveredTime < DateTime.Now;

        public bool CanCreateTrip => Trip is null;

        public bool IsValidTrip => Trip is not null && Trip.ValidTrip;

        public bool CanPushToQueue => DelayReports
            .Any(x => x.AgentId.HasValue && x.Status == DelayReportStatus.PENDING);

        public TripAssignedStatus DelayState
            => IsValidTrip ? TripAssignedStatus.ASSIGNED : TripAssignedStatus.NOT_ASSIGNED;

        private Order()
        {

        }

        private Order(int id, int vendorId, int customerId, DateTime deliveredTime)
        {
            var now = DateTime.Now;
            if (deliveredTime <= now)
            {
                throw new LogicException("Deliver Time Is Not Valid");
            }
            Id = id;
            VendorId = vendorId;
            CustomerId = customerId;
            CreatedTime = now;
            DeliveredTime = deliveredTime;
        }


        private Order(int vendorId, int customerId, DateTime deliveredTime)
        {
            var now = DateTime.Now;
            if (deliveredTime <= now)
            {
                throw new LogicException("Deliver Time Is Not Valid");
            }

            VendorId = vendorId;
            CustomerId = customerId;
            CreatedTime = now;
            DeliveredTime = deliveredTime;
        }

        public static Order Create(int vendorId, int customerId, DateTime deliveredTime)
        {
            return new Order(vendorId, customerId, deliveredTime);
        }

        public static List<Order> CreateMock()
        {

            var order1 = new Order(1, 1, 1, DateTime.Now.AddMinutes(15));
            order1.SetDeliveredAt(DateTime.Now.AddMinutes(5));

            var order2 = new Order(2, 1, 2, DateTime.Now.AddMinutes(15));
            order2.SetDeliveredAt(DateTime.Now.AddMinutes(20));

            var order3 = new Order(3, 2, 2, DateTime.Now.AddMinutes(3));

            return new List<Order> { order1, order2, order3 };
        }

        public void SetDeliveredAt(DateTime time)
        {
            if (CreatedTime > time)
            {
                throw new LogicException("Deliver Time Is Not Valid");
            }

            DeliveredAt = time;
        }

        public DelayReport Report()
        {
            if (!CanReportDelay)
            {
                throw new LogicException("Can Not Report Delay");
            }

            return DelayReport.Create(Id);
        }

        public Trip StartTrip()
        {
            if (!CanCreateTrip)
            {
                throw new LogicException("Can Not Create Trip");
            }

            var trip = Trip.Create(Id, TripStatus.AT_VENDOR);

            Trip = trip;

            return trip;
        }

        public Trip CreateDeliveredTrip()
        {
            if (!CanCreateTrip)
            {
                throw new LogicException("Can Not Create Trip");
            }

            var trip = Trip.Create(Id, TripStatus.DELIVERED);

            Trip = trip;

            return trip;
        }

    }

}