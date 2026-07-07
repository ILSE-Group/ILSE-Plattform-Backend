using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics
{
    public class Topic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<Room> _rooms;
        public IReadOnlyList<Room> Rooms => _rooms;

        private Topic() { }
        private Topic(Guid id, string name, List<Room> rooms)
        {
            Id = id;
            Name = name;
            _rooms = rooms;
        }

        public static Topic CreateNew(string name)
        {
            return new Topic(Guid.NewGuid(), name, []);
        }

        public static Topic Reconstruct(Guid id, string name, List<Room> rooms)
        {
            return new Topic(id, name, rooms);
        }

        public void AddRoom(Room room)
        {
            if (!_rooms.Contains(room))
                _rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            _rooms.Remove(room);
        }
    }
}
