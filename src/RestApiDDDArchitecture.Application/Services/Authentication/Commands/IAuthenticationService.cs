using ErrorOr;
using FluentResults;
using OneOf;
using RestApiDDDArchitecture.Application.Common.Errors;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
	// simple implementation
	// AuthenticationResult Register(string firstName, string lastName, string email, string password);
	
	// using oneOf package
	// OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
	
	// using fluentResults package
	// Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
	
	// using errorOr package
	ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
	
	
}