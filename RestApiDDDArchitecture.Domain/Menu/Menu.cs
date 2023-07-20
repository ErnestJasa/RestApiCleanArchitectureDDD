using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;
using RestApiDDDArchitecture.Domain.Menu.Entities;
using RestApiDDDArchitecture.Domain.Menu.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuReview.ValueObjects;

namespace RestApiDDDArchitecture.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
	private readonly List<MenuSection> _sections = new();
	private readonly List<DinnerId> _dinnerIds = new();
	private readonly List<MenuReviewId> _menuReviewIds = new();
	public string Name { get; }
	public string Description { get; }
	public float AverageRating { get; }
	
	public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
	
	public HostId HostId { get; }
	public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
	public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
	
	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }
	
	private Menu(MenuId menuId,
              string name,
              string description,
              HostId hostId,
              DateTime createdDateTime,
              DateTime updatedDateTime)	: base(menuId)
	{
		Name = name;
		Description = description;
		HostId = hostId;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}
	
	public static Menu Create(string name,
                           string description,
                           HostId hostId)
	{
		return new(MenuId.CreateUnique(),
             name,
             description,
             hostId,
             DateTime.UtcNow,
             DateTime.UtcNow);
	}
	
}