using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.BillAggregate.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; }

        private BillId(Guid value)
        {
            Value = value;
        }
        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}