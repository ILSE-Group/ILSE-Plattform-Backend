using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class MultipleChoiceMultiAnswerExercise : Exercise
    {
        private readonly List<MCOption> _options;
        public IReadOnlyList<MCOption> Options => _options;

        private readonly List<MCOption> _correctOptionIds;
        public IReadOnlyList<MCOption> CorrectOptionIds => _correctOptionIds;

        private MultipleChoiceMultiAnswerExercise() : base() { }

        private MultipleChoiceMultiAnswerExercise(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            List<MCOption> options,
            List<MCOption> correctOptionIds)
            : base(id, title, description, experiencePoints)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _correctOptionIds = correctOptionIds ?? throw new ArgumentNullException(nameof(correctOptionIds));
        }

        public static MultipleChoiceMultiAnswerExercise CreateNew(
            string title,
            string description,
            int experiencePoints,
            List<MCOption> options,
            List<MCOption> correctOptionIds)
        {
            return new MultipleChoiceMultiAnswerExercise(
                Guid.NewGuid(),
                title,
                description,
                experiencePoints,
                options,
                correctOptionIds
            );
        }

        public static MultipleChoiceMultiAnswerExercise Reconstruct(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            List<MCOption> options,
            List<MCOption> correctOptionIds)
        {
            return new MultipleChoiceMultiAnswerExercise(
                id,
                title,
                description,
                experiencePoints,
                options,
                correctOptionIds
            );
        }

        public override bool ValidateAnswer(object answer)
        {
            if (answer is not List<int> selectedIndices) throw new ArgumentException("Expected List<int> for multiple choice answer.", nameof(answer));
 
            var correctIndices = _options
                .Select((option, index) => new { option, index })
                .Where(x => _correctOptionIds.Contains(x.option))
                .Select(x => x.index)
                .ToList();
 
            return selectedIndices.Count == correctIndices.Count && selectedIndices.OrderBy(i => i).SequenceEqual(correctIndices.OrderBy(i => i));

        }
    }
}