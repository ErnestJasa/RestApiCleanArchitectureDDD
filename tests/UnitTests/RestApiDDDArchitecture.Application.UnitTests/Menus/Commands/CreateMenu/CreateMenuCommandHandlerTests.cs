using FluentAssertions;

using Moq;

using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Application.Menus.Commands.CreateMenu;
using RestApiDDDArchitecture.Application.UnitTests.Menus.Commands.TestUtils;
using RestApiDDDArchitecture.Application.UnitTests.TestUtils.Menus.Extensions;

namespace RestApiDDDArchitecture.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCOmandHandlerTests
{
	private readonly CreateMenuCommandHandler _handler;
	private readonly Mock<IMenuRepository> _mockMenuRepository;
	public CreateMenuCOmandHandlerTests()
	{
		_mockMenuRepository = new Mock<IMenuRepository>();
		_handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
	}

	// public void T1_T2_T3
	// T1: System under test (SUT) - logical component we're testing
	// T2: Scenario - what we're testing
	// T3: Expected outcome - what we expect the logical component to do
	[Theory]
	[MemberData(nameof(ValidCreateMenuCommands))]
	public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
	{
		// Arrange
		// Get hold of a valid menu
		//var createMenuCommand = CreateMenuCommandUtils.CreateCommand();
		// Act
		// Invoke the handler
		var result = await _handler.Handle(createMenuCommand, default);
		
		// Assert
		result.IsError.Should().BeFalse();		
		// 1. Validate correct menu created based on command
		result.Value.ValidateCreatedFrom(createMenuCommand);
		// 2. Menu added to repository
		_mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);
	}

	public static IEnumerable<object[]> ValidCreateMenuCommands()
	{
		yield return new[] { CreateMenuCommandUtils.CreateCommand() };
		
		yield return new[] 
		{ 
			CreateMenuCommandUtils.CreateCommand(
			sections: CreateMenuCommandUtils.CreateMenuSectionsCommand(sectionCount: 3))
		};
		yield return new[] 
		{ 
			CreateMenuCommandUtils.CreateCommand(
			sections: CreateMenuCommandUtils.CreateMenuSectionsCommand(
				sectionCount: 3,
				CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
		};
		
	}
}