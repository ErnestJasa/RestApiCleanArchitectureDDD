using RestApiDDDArchitecture.Domain.UserAggregate;

namespace RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
	string GenerateToken(User user);
}