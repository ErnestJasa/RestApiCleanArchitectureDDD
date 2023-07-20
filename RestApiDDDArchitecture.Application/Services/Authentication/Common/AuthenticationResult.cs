using RestApiDDDArchitecture.Domain.User;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Common;

public record AuthenticationResult
(
	User User,
	string Token
);