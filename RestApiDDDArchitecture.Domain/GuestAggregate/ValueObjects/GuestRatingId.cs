using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public string Value { get; }

        private GuestRatingId(Guid value)
        {
            Value = value.ToString();
        }
        public static GuestRatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}