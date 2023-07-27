using ErrorOr;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
	// simple implementation 
	// AuthenticationResult Login(string email, string password);

	// using errorOr package
	ErrorOr<AuthenticationResult> Login(string email, string password);
}