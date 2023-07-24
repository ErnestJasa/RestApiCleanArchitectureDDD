using RestApiDDDArchitecture.Domain.MenuAggregate;

namespace RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
	void Add(Menu menu);
}