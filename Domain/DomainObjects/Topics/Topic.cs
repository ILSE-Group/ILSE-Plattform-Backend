namespace Domain.DomainObjects.Topics
{
    public class Topic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Guid> Rooms{ get; private set; }

        private Topic()
        {
            Name = string.Empty;
            Rooms = [];
        }

        public Topic(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Rooms = [];
        }
    }
}
