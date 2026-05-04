namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class DragAndDropMapping
    {
        public Guid Id { get; }
        public Guid ItemId { get; }
        public Guid DropZoneId { get; }

        private DragAndDropMapping(Guid id, Guid itemId, Guid dropZoneId)
        {
            Id = id;
            ItemId = itemId;
            DropZoneId = dropZoneId;
        }

        public static DragAndDropMapping CreateNew(Guid itemId, Guid dropZoneId)
        {
            return new DragAndDropMapping(Guid.NewGuid(), itemId, dropZoneId);
        }

        public static DragAndDropMapping Reconstruct(Guid id, Guid itemId, Guid dropZoneId)
        {
            return new DragAndDropMapping(id, itemId, dropZoneId);
        }
    }
}
