namespace Domain.DomainObjects.Progresses
{
    public class RoomProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid RoomId { get; private set; }
        public List<Guid> CompletedRooms { get; private set; }

        private RoomProgress(Guid id, Guid userId, Guid roomId, List<Guid> completedRooms)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            CompletedRooms = completedRooms ?? [];
        }

        public static RoomProgress CreateNew(Guid userId, Guid roomId)
        {
            return new RoomProgress(Guid.NewGuid(), userId, roomId, []);
        }

        public static RoomProgress Reconstruct(Guid id, Guid userId, Guid roomId, List<Guid> completedRooms)
        {
            return new RoomProgress(id, userId, roomId, completedRooms ?? []);
        }

        public void MarkAsCompleted()
        {
            if (!CompletedRooms.Contains(RoomId))
            {
                CompletedRooms.Add(RoomId);
            }
        }
    }
}