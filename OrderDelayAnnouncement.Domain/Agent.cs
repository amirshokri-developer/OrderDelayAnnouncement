namespace OrderDelayAnnouncement.Domain
{
    public class Agent
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public List<DelayReport> DelayReports { get; set; } = new List<DelayReport>();

        private Agent()
        {

        }

        private Agent(string name)
        {
            Name = name;
        }

        private Agent(int id , string name)
        {
            Id = id;
            Name = name;
        }

        public static Agent Create(string name)
        {
            return new Agent(name);
        }

        public static List<Agent> CreateMock()
        {
            return new List<Agent> { new Agent(1 , "Reza") , new Agent (2 , "Hassan") };
        }
    }
}