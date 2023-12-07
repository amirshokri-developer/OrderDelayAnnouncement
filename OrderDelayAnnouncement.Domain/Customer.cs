namespace OrderDelayAnnouncement.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        private Customer()
        {

        }

        private Customer(string name)
        {
            Name = name;
        }

        private Customer(int id , string name)
        {
            Id = id;
            Name = name;
        }


        public static Customer Create(string name)
        {
            return new Customer(name);
        }

        public static List<Customer> CreateMock()
        {
            return new List<Customer> { new Customer(1, "Amir"), new Customer(2, "Ali") };
        }
    }
}