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

        public List<Trip> Trips { get; } = new List<Trip>();

        public List<DelayReport> DelayReports { get; } = new List<DelayReport>();

        public bool CanReportDelay => DeliveredTime < DateTime.Now;

        public bool CanCreateTrip => !Trips.Any();

        public bool IsValidTrip => Trips.Any() && Trips.All(x => x.ValidTrip);

        public bool CanPushToQueue => DelayReports
            .Any(x => x.AgentId.HasValue && x.Status == DelayReportStatus.PENDING);

        public TripAssignedStatus DelayState
            => IsValidTrip ? TripAssignedStatus.ASSIGNED : TripAssignedStatus.NOT_ASSIGNED;

        private Order()
        {

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

            Trips.Add(trip);

            return trip;
        }

        public Trip CreateDeliveredTrip()
        {
            if (!CanCreateTrip)
            {
                throw new LogicException("Can Not Create Trip");
            }

            var trip = Trip.Create(Id , TripStatus.DELIVERED);

            Trips.Add(trip);

            return trip;
        }

    }

}