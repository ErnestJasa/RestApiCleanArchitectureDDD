using RestApiDDDArchitecture.Domain.UserAggregate;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Common;

public record AuthenticationResult
(
	User User,
	string Token
);