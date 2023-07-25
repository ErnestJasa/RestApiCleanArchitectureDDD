using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects
{
	public class ReservationId : ValueObject
	{
		public Guid Value { get; private set; }

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