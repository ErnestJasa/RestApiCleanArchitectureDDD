using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
	public Guid Value { get; }

	private HostId(Guid value)
	{
		Value = value;
	}
	public static HostId Create(string id)
	{
		return new(Guid.Parse(id));
	}
	public static HostId CreateUnique()
	{
		return new(Guid.NewGuid());
	}
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}
