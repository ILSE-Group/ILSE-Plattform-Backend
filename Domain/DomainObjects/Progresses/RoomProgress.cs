namespace Domain.DomainObjects.Progresses
{
    public class RoomProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid RoomId { get; private set; }
        public List<Guid> CompletedRooms { get; private set; }

        private RoomProgress()
        {
            CompletedRooms = [];
        }

        public RoomProgress(Guid userId, Guid roomId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            RoomId = roomId;
            CompletedRooms = [];
        }

        public void MarkAsCompleted()
        {
            CompletedRooms.Add(RoomId);
        }
    }
}