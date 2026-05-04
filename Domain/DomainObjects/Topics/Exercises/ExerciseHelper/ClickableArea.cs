namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class ClickableArea
    {
        public Guid Id { get; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        private ClickableArea(Guid id, int x, int y, int width, int height)
        {
            Id = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public static ClickableArea CreateNew(int x, int y, int width, int height)
        {
            return new ClickableArea(Guid.NewGuid(), x, y, width, height);
        }

        public static ClickableArea Reconstruct(Guid id, int x, int y, int width, int height)
        {
            return new ClickableArea(id, x, y, width, height);
        }

    }
}
