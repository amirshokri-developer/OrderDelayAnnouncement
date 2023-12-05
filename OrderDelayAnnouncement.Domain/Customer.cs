namespace OrderDelayAnnouncement.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private Customer()
        {

        }

        private Customer(string name)
        {
            Name = name;
        }

        public static Customer Create(string name)
        {
            return new Customer(name);
        }
    }
}