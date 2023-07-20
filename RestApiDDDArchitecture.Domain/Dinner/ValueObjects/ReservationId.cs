﻿using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.Dinner.ValueObjects
{
    public class ReservationId : ValueObject
    {
        public Guid Value { get; }

        private ReservationId(Guid value)
        {
            Value = value;
        }
        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}