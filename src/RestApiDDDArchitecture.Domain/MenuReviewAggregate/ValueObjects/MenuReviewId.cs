using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
	public override Guid Value { get; protected set; }

	private MenuReviewId(Guid value)
	{
		Value = value;
	} 
	public static MenuReviewId CreateUnique()
	{
		return new(Guid.NewGuid());
	}
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}
