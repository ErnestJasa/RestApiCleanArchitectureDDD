using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Domain.MenuAggregate;

namespace RestApiDDDArchitecture.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
	private static readonly List<Menu> _menus = new();
	public void Add(Menu menu)
	{
		_menus.Add(menu);
	}
}