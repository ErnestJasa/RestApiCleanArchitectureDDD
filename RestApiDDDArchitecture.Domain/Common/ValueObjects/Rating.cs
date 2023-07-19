using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public float Value { get; }

        private Rating(float value)
        {
            Value = value;
        }

        public static Rating Create(float rating)
        {
            return new(rating);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private Rating()
        {
        }
    }
}
