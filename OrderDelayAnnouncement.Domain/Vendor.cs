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

        private Vendor(int id , string name)
        {
            Id = id;
            Name = name;
        }

        public static Vendor Create(string name)
        {
            return new Vendor(name);
        }


        public static List<Vendor> CreateMock()
        {
            return new List<Vendor> { new Vendor(1, "Motahari"), new Vendor(2, "Enghelab") };
        }


    }
}