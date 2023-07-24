using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Common.ValueObjects;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuAggregate.Entities;
using RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuReviewAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
	private readonly List<MenuSection> _sections = new();
	private readonly List<DinnerId> _dinnerIds = new();
	private readonly List<MenuReviewId> _menuReviewIds = new();
	public string Name { get; }
	public string Description { get; }
	public AverageRating? AverageRating { get; }	
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
			  List<MenuSection>? sections,
			  DateTime createdDateTime,
			  DateTime updatedDateTime)	: base(menuId)
	{
		Name = name;
		Description = description;
		HostId = hostId;
		if (sections is not null)
		{			
			_sections = sections;
		}
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}
	
	public static Menu Create(string name,
						   string description,
						   HostId hostId,
						   List<MenuSection>? menuSections)
	{
		return new(MenuId.CreateUnique(),
			 name,
			 description,
			 hostId,
			 menuSections,
			 DateTime.UtcNow,
			 DateTime.UtcNow);
	}
	
}