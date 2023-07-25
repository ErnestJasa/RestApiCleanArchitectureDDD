using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
	public Guid Value { get; private set; }

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
