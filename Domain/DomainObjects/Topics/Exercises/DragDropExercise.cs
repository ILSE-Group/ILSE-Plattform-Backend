using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class DragAndDropExercise : Exercise
    {
        private readonly List<DraggableItem> _items;
        public IReadOnlyList<DraggableItem> Items => _items;

        private readonly List<DropZone> _zones;
        public IReadOnlyList<DropZone> Zones => _zones;

        private readonly List<DragAndDropMapping> _correctMappings;
        public IReadOnlyList<DragAndDropMapping> CorrectMappings => _correctMappings;

        private DragAndDropExercise(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            List<DraggableItem> items,
            List<DropZone> zones,
            List<DragAndDropMapping> correctMappings)
            : base(id, title, description, experiencePoints)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _zones = zones ?? throw new ArgumentNullException(nameof(zones));
            _correctMappings = correctMappings ?? throw new ArgumentNullException(nameof(correctMappings));
        }

        public static DragAndDropExercise CreateNew(string title,string description,int experiencePoints,List<DraggableItem> items,List<DropZone> zones,List<DragAndDropMapping> correctMappings)
        {
            return new DragAndDropExercise(
                Guid.NewGuid(),
                title,
                description,
                experiencePoints,
                items,
                zones,
                correctMappings
            );
        }

        public static DragAndDropExercise Reconstruct(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            List<DraggableItem> items,
            List<DropZone> zones,
            List<DragAndDropMapping> correctMappings)
        {
            return new DragAndDropExercise(
                id,
                title,
                description,
                experiencePoints,
                items,
                zones,
                correctMappings
            );
        }

        public override Exercise ValidateAnswer(object answer)
        {
            throw new NotImplementedException();
        }
    }
}