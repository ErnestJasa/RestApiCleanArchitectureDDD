using ErrorOr;

using MediatR;

using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuAggregate;
using RestApiDDDArchitecture.Domain.MenuAggregate.Entities;

namespace RestApiDDDArchitecture.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
	private readonly IMenuRepository _menuRepository;

	public CreateMenuCommandHandler(IMenuRepository menuRepository)
	{
		_menuRepository = menuRepository;
	}

	public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
		// Create Menu
		var menu = Menu.Create(
			name: request.Name,
			description: request.Description,
			hostId: HostId.Create(request.HostId),
			menuSections: request.Sections.ConvertAll(section => MenuSection.Create(
				section.Name,
				section.Description,
				section.Items.ConvertAll(item => MenuItem.Create(
					item.Name,
					item.Description
				)))));
				
		// Persist Menu
		_menuRepository.Add(menu);
		
		// Return Menu		
		return menu;
	}
}
