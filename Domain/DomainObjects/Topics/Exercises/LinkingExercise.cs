using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;

namespace Domain.DomainObjects.Topics.Exercises
{
    public class LinkingExercise : Exercise
    {
        private readonly List<Link> _leftItems;
        public IReadOnlyList<Link> LeftItems => _leftItems;

        private readonly List<Link> _rightItems;
        public IReadOnlyList<Link> RightItems => _rightItems;

        private readonly List<Link> _correctLinks;
        public IReadOnlyList<Link> CorrectLinks => _correctLinks;

        private LinkingExercise() : base() { }

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

        public override bool ValidateAnswer(object answer)
        {
            if (answer is not List<(int LeftIndex, int RightIndex)> links) throw new ArgumentException("Expected List<(int LeftIndex, int RightIndex)> for linking answer.", nameof(answer));
 
            if (links.Count != _correctLinks.Count) return false;
 
            return links.All(l =>
            {
                if (l.LeftIndex < 0 || l.LeftIndex >= _leftItems.Count) return false;
                if (l.RightIndex < 0 || l.RightIndex >= _rightItems.Count) return false;
 
                var leftText = _leftItems[l.LeftIndex].LeftItem;
                var rightText = _rightItems[l.RightIndex].RightItem;
 
                return _correctLinks.Any(cl => cl.LeftItem == leftText && cl.RightItem == rightText);
            });

        }
    }
}
