using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.VisualBasic.FileIO;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class MultipleChoiceMultiAnswerExercise : Exercise
    {
        private readonly List<MCOption> _options;
        public IReadOnlyList<MCOption> Options => _options;

        private readonly List<Guid> _correctOptionIds;
        public IReadOnlyList<Guid> CorrectOptionIds => _correctOptionIds;

        private MultipleChoiceMultiAnswerExercise(
            Guid id,
            string title,
            string description,
            int experiencePoints,
            List<MCOption> options,
            List<Guid> correctOptionIds)
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
            List<Guid> correctOptionIds)
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
            List<Guid> correctOptionIds)
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

        public override Exercise ValidateAnswer(object answer)
        {
            throw new NotImplementedException();
        }
    }
}