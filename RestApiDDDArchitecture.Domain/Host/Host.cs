using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Common.ValueObjects;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;
using RestApiDDDArchitecture.Domain.Menu.ValueObjects;
using RestApiDDDArchitecture.Domain.User.ValueObjects;

namespace RestApiDDDArchitecture.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
	private readonly List<MenuId> _menuIds = new();
	private readonly List<DinnerId> _dinnerIds = new();

	public string FirstName { get; }
	public string LastName { get; }
	public string ProfileImage { get; }
	public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }		
	
	public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
	public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
	
	private Host(HostId hostId,
				 string firstName,
				 string lastName,
				 string profileImage,
                 AverageRating averageRating,
                 UserId userId,
				 DateTime createdDateTime,
				 DateTime updatedDateTime) :base(hostId)
	{
		FirstName = firstName;
		LastName = lastName;
		ProfileImage = profileImage;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
		UserId = userId;
	}
	public static Host Create(string firstName, string lastName, string profileImage, UserId userId)
	{
		return new(
			HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
	}
}