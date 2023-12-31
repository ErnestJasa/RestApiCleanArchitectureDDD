﻿using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private UserId(Guid value)
        {
            Value = value;
        }
        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
       
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
