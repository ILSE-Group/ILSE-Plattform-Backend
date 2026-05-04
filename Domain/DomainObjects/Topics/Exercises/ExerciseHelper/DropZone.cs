namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class DropZone
    {
        public Guid Id { get; }
        public string Label { get; }

        private DropZone(Guid id, string label)
        {
            Id = id;
            Label = label;
        }

        public static DropZone CreateNew(string label)
        {
            return new DropZone(Guid.NewGuid(), label);
        }

        public static DropZone Reconstruct(Guid id, string label)
        {
            return new DropZone(id, label);
        }
    }
}
