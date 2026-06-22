using Domain.Utility;

namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class Link
    {
        public Guid Id { get; }
        public string LeftItem { get; }
        public string RightItem { get; }

        private Link(Guid id, string leftItem, string rightItem)
        {
            Guard.AgainstEmptyGuid(id, nameof(id));

            Id = id;
            LeftItem = leftItem;
            RightItem = rightItem;
        }

        public static Link CreateNew(string leftItem, string rightItem)
        {
            return new Link(Guid.NewGuid(), leftItem, rightItem);
        }

        public static Link Reconstruct(Guid id, string leftItem, string rightItem)
        {
            return new Link(id, leftItem, rightItem);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Link other) return false;
            return LeftItem == other.LeftItem && RightItem == other.RightItem;
        }

        public override int GetHashCode() => HashCode.Combine(LeftItem, RightItem);
    }
}
