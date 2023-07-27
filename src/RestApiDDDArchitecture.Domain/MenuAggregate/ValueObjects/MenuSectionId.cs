using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
	public Guid Value { get; private set; }
	
	private MenuSectionId(Guid value)
	{
		Value = value;
	}
	
    
	public static MenuSectionId Create(Guid value)
	{
		return new MenuSectionId(value);
	}
	public static MenuSectionId CreateUnique()
	{
		return new(Guid.NewGuid());
	}
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
#pragma warning disable CS8618
	private MenuSectionId()
	{
	}
#pragma warning restore CS8618
}