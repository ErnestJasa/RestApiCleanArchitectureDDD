using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Common.ValueObjects;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuAggregate.Entities;
using RestApiDDDArchitecture.Domain.MenuAggregate.Events;
using RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuReviewAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
	private readonly List<MenuSection> _sections = new();
	private readonly List<DinnerId> _dinnerIds = new();
	private readonly List<MenuReviewId> _menuReviewIds = new();
	public string Name { get; private set; }
	public string Description { get; private set; }
	public AverageRating AverageRating { get; private set; }	
	public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
	
	public HostId HostId { get; private set; }
	public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
	public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
	
	public DateTime CreatedDateTime { get; private set; }
	public DateTime UpdatedDateTime { get; private set; }
	
	private Menu(MenuId menuId,
			  string name,
			  string description,
			  HostId hostId,
			  AverageRating averageRating,
			  List<MenuSection> sections,
			  DateTime createdDateTime,
			  DateTime updatedDateTime)	: base(menuId)
	{
		Name = name;
		Description = description;
		HostId = hostId;					
		AverageRating = averageRating;
		_sections = sections;		
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}
	
	public static Menu Create(string name,
						   string description,
						   HostId hostId,
						   List<MenuSection>? menuSections = null)
	{
		var menu = new Menu(MenuId.CreateUnique(),
			 name,
			 description,
			 hostId,
			 AverageRating.CreateNew(),
			 menuSections ?? new(),
			 DateTime.UtcNow,
			 DateTime.UtcNow);
		
		menu.AddDomainEvent(new MenuCreated(menu)); 
		
		return menu;
	}
	
	#pragma warning disable CS8618
		private Menu()
		{			
		}	
	#pragma warning restore CS8618
	
}