namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class MCOption
    {
        public Guid Id { get; }
        public string OptionText { get; }
        
        private MCOption(Guid id, string text)
        {
            Id = id;
            OptionText = text;
        }

        public static MCOption CreateNew(string text)
        {
            return new MCOption(Guid.NewGuid(), text);
        }

        public static MCOption Reconstruct(Guid id, string text)
        {
            return new MCOption(id, text);
        }
    }
}
