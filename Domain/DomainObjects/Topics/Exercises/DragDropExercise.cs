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

        private DragAndDropExercise() : base() { }

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

        public override bool ValidateAnswer(object answer)
        {
            if (answer is not List<(int ItemIndex, int ZoneIndex)> mappings) throw new ArgumentException("Expected List<(int ItemIndex, int ZoneIndex)> for drag and drop answer.", nameof(answer));
 
            if (mappings.Count != _correctMappings.Count) return false;
 
            return mappings.All(m =>
            {
                if (m.ItemIndex < 0 || m.ItemIndex >= _items.Count) return false;
                if (m.ZoneIndex < 0 || m.ZoneIndex >= _zones.Count) return false;
 
                var itemId = _items[m.ItemIndex].Id;
                var zoneId = _zones[m.ZoneIndex].Id;
 
                return _correctMappings.Any(cm => cm.ItemId == itemId && cm.DropZoneId == zoneId);
            });
        }
    }
}