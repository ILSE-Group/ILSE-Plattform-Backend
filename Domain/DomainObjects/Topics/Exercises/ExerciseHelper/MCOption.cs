namespace Domain.DomainObjects.Topics.Exercises.ExerciseHelper
{
    public class MCOption
    {
        public Guid Id { get; }
        public string OptionText { get; }
        
        private MCOption(Guid id, string optionText)
        {
            Id = id;
            OptionText = optionText;
        }

        public static MCOption CreateNew(string optionText)
        {
            return new MCOption(Guid.NewGuid(), optionText);
        }

        public static MCOption Reconstruct(Guid id, string optionText)
        {
            return new MCOption(id, optionText);
        }
    }
}
