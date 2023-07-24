using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
	public Guid Value { get; }
	
	private MenuId(Guid value)
	{
		Value = value;
	}
	
	public static MenuId CreateUnique()
	{
		return new(Guid.NewGuid());
	}
	
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}