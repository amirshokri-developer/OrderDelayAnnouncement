namespace OrderDelayAnnouncement.Domain
{
    public class Agent
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        private Agent()
        {

        }

        private Agent(string name)
        {
            Name = name;
        }

        public static Agent Create(string name)
        {
            return new Agent(name);
        }
    }
}