using RestApiDDDArchitecture.Application.Menus.Commands.CreateMenu;
using RestApiDDDArchitecture.Application.UnitTests.TestUtils.Constants;
namespace RestApiDDDArchitecture.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
	// menus
	public static CreateMenuCommand CreateCommand(
		List<CreateMenuSectionCommand>? sections = null)=>
		new CreateMenuCommand(
			Constants.Host.Id.ToString()!,
			Constants.Menu.Name,
			Constants.Menu.Description,
			sections ?? CreateMenuSectionsCommand());
	
	// sections	
	public static List<CreateMenuSectionCommand> CreateMenuSectionsCommand(
		int sectionCount = 1,
		List<CreateMenuItemCommand>? items = null) =>
		Enumerable.Range(0, sectionCount)
			.Select(index => new CreateMenuSectionCommand(
				Constants.Menu.SectionNameFromIndex(index),
				Constants.Menu.SectionDescriptionFromIndex(index),
				items ?? CreateItemsCommand())).ToList();
	// items	
	public static List<CreateMenuItemCommand> CreateItemsCommand(int itemCount = 1)=>
		Enumerable.Range(0, itemCount)
			.Select(index => new CreateMenuItemCommand(
				Constants.Menu.ItemDescriptionFromIndex(index),
				Constants.Menu.ItemDescriptionFromIndex(index))).ToList();
}