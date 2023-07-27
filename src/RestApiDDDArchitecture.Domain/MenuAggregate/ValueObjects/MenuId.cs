using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
	public override Guid Value { get; protected set; }
		
	private MenuId(Guid value)
	{
		Value = value;
	}
	
	
    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
	
	public static MenuId CreateUnique()
	{
		return new(Guid.NewGuid());
	}
	
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
#pragma warning disable CS8618
	private MenuId()
	{
	}
#pragma warning restore CS8618
}