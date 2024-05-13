using CSharpFunctionalExtensions;

namespace Domain.Shared.ValueObjects
{
    public class Salary : ValueObject
    {
        public int Amount { get; }
        public Currency Currency { get; }
        public Salary(int amount, Currency currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount can't be negative", nameof(amount));

            Currency = currency;
            Amount = amount;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Currency;
            yield return Amount;
        }
    }
}
