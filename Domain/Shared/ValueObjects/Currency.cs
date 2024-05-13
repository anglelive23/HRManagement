using CSharpFunctionalExtensions;

namespace Domain.Shared.ValueObjects
{
    public class Currency : ValueObject
    {
        public const int Length = 100;
        public string Value { get; }

        public Currency(string value)
        {
            if (value.Length > Length)
                throw new ArgumentException($"Length must be {Length}.", nameof(value));

            Value = value;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
