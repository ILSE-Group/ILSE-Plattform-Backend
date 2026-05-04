namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class DraggableItem
    {
        public Guid Id { get; }
        public string Content { get; }

        private DraggableItem(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public static DraggableItem CreateNew(string content)
        {
            return new DraggableItem(Guid.NewGuid(), content);
        }

        public static DraggableItem Reconstruct(Guid id, string content)
        {
            return new DraggableItem(id, content);
        }
    }
}
