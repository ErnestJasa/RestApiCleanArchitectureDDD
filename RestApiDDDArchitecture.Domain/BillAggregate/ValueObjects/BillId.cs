﻿using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.BillAggregate.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

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