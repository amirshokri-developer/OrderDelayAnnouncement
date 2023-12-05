namespace OrderDelayAnnouncement.Domain
{
    public class Trip
    {
        public int Id { get; private set; }

        public int OrderId { get; private set; }

        public TripStatus Status { get; private set; }

        public Order Order { get; set; }

        private Trip()
        {

        }

        private Trip(int orderId, TripStatus status)
        {            
            OrderId = orderId;
            Status = status;
        }

        public static Trip Create(int orderId , TripStatus status)
        {
            return new Trip(orderId, status);
        }

        public void SetTripToDelivered()
        {
            Status = TripStatus.DELIVERED;
        }

        public bool ValidTrip
               => (Status == TripStatus.AT_VENDOR ||
                   Status == TripStatus.ASSIGNED || 
                   Status == TripStatus.PICKED);
        
    }
}