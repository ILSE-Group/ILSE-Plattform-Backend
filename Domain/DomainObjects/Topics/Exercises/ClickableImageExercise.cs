using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class ClickableImageExercise : Exercise<ClickableArea>
    {
        public string ImageUrl { get; private set; }
        public ClickableArea CorrectArea { get; private set; }

        private readonly List<ClickableArea> _clickableAreas;
        public IReadOnlyList<ClickableArea> ClickableAreas => _clickableAreas;

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

        public override bool ValidateAnswer(ClickableArea answer)
        {
            return CorrectArea.Equals(answer);
        }

    }
}
