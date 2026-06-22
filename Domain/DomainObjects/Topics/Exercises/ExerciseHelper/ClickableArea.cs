namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class ClickableArea
    {
        public Guid Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

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

        public override bool Equals(object? obj)
        {
            if (obj is not ClickableArea other) return false;
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);
    }
}
