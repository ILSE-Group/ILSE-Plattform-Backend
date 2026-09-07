using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class ClickableImageExercise : Exercise
    {
        public string ImageUrl { get; private set; }

        private readonly List<ClickableArea> _clickableAreas;
        public IReadOnlyList<ClickableArea> ClickableAreas => _clickableAreas;

        private ClickableImageExercise() : base() { }

        private ClickableImageExercise(
            Guid id, 
            string title, 
            string description, 
            int experiencePoints, 
            string imageUrl, 
            List<ClickableArea> clickableAreas) 
            : base(id, title, description, experiencePoints)
        {
            ImageUrl = imageUrl;
            _clickableAreas = clickableAreas;
        }

        public static ClickableImageExercise CreateNew(
            string title,
            string description,
            int experiencePoints,
            string imageUrl,
            List<ClickableArea> clickableAreas)
        {
            return new ClickableImageExercise(Guid.NewGuid(), title, description, experiencePoints, imageUrl, clickableAreas);
        }

        public static ClickableImageExercise Reconstruct(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            string imageUrl,
            List<ClickableArea> clickableAreas)
        {
            return new ClickableImageExercise(id, title, description, experiencePoints, imageUrl, clickableAreas);
        }

        public override bool ValidateAnswer(object answer)
        {
            if (answer is not ValueTuple<int, int> point) throw new ArgumentException("Expected a (int X, int Y) tuple for clickable image answer.", nameof(answer));
 
            var x = point.Item1;
            var y = point.Item2;
 
            return _clickableAreas.Any(area =>
                x >= area.X && x <= area.X + area.Width &&
                y >= area.Y && y <= area.Y + area.Height);
        }

    }
}
