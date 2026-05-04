namespace Domain.Utility
{
    internal class Guard
    {
        internal static void AgainstEmptyGuid(Guid value, string parameterName)
        {
            if (value == Guid.Empty)
                throw new ArgumentException($"Parameter {parameterName} cannot be an empty Guid.");
        }
    }
}
