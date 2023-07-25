using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Domain.MenuAggregate;

namespace RestApiDDDArchitecture.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
	private readonly AppDbContext _dbContext;

	public MenuRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public void Add(Menu menu)
	{
		_dbContext.Add(menu);
		
		_dbContext.SaveChanges();
	}
}