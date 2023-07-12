using RestApiDDDArchitecture.Domain.Entities;

namespace RestApiDDDArchitecture.Application.Services.Authentication;

public record AuthenticationResult
(
	User User,
	string Token
);