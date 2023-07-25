using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public string Value { get; }

        private GuestId(Guid value)
        {
            Value = value.ToString();
        }
        public static GuestId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
