namespace OrderDelayAnnouncement.Domain
{
    public class Vendor
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<Order> Orders { get; set; } = new List<Order>();

        private Vendor()
        {

        }

        private Vendor(string name)
        {
            Name = name;
        }

        public static Vendor Create(string name)
        {
            return new Vendor(name);
        }

        

    }
}