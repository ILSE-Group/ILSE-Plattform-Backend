namespace Domain.DomainObjects.User
{
    public class Username
    {
        public string Value { get; private set; }

        private Username() { }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be empty.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}