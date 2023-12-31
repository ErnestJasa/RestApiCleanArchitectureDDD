﻿using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects
{
    public sealed class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GuestId(Guid value)
        {
            Value = value;
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
