using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class LinkingExercise : Exercise<List<Link>>
    {

        private readonly List<Link> _leftItems;
        public IReadOnlyList<Link> LeftItems => _leftItems;

        private readonly List<Link> _rightItems;
        public IReadOnlyList<Link> RightItems => _rightItems;

        private readonly List<Link> _correctLinks;
        public IReadOnlyList<Link> CorrectLinks => _correctLinks;

        private LinkingExercise(Guid id, string title, string description, int experiencePoints, List<Link> leftItems, List<Link> rightItems, List<Link> correctLinks) 
           : base(id, title, description, experiencePoints)
        {
            _leftItems = leftItems;
            _rightItems = rightItems;
            _correctLinks = correctLinks;
        }

        public static LinkingExercise CreateNew(string title, string description, int experiencePoints, List<Link> leftItems, List<Link> rightItems, List<Link> correctLinks)
        {
            return new LinkingExercise(Guid.NewGuid(), title, description, experiencePoints, leftItems, rightItems, correctLinks);
        }

        public static LinkingExercise Reconstruct(Guid id, string title, string description, int experiencePoints, List<Link> leftItems, List<Link> rightItems, List<Link> correctLinks)
        {
            return new LinkingExercise(id, title, description, experiencePoints, leftItems, rightItems, correctLinks);
        }

        public override bool ValidateAnswer(List<Link> answer)
        {
            if (answer.Count != _correctLinks.Count) return false;
            return answer.All(a => _correctLinks.Any(c => c.Equals(a)));
        }
    }
}
