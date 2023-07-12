using ErrorOr;
using FluentResults;
using OneOf;
using RestApiDDDArchitecture.Application.Common.Errors;

namespace RestApiDDDArchitecture.Application.Services.Authentication;

public interface IAuthenticationService
{
	// simple implementation
	// AuthenticationResult Register(string firstName, string lastName, string email, string password);
	
	// using oneOf package
	// OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
	
	// using fluentResults package
	// Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
	
	// using errorOr package
	ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
	
	// simple implementation 
	// AuthenticationResult Login(string email, string password);
	
	// using errorOr package
	ErrorOr<AuthenticationResult> Login(string email, string password);
}