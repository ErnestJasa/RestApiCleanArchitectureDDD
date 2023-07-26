using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.UserAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
	public override string Value { get; protected set;}

	
	private HostId(string value)
	{
		Value = value;
	}
	
	public static HostId Create(string value)
	{
		return new HostId(value);
	}
    public static HostId Create(UserId userId)
    {
        return new HostId($"Host_{userId.Value}");
    }
	
	public static HostId CreateUnique()
	{
		return new(Guid.NewGuid().ToString());
	}
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}
