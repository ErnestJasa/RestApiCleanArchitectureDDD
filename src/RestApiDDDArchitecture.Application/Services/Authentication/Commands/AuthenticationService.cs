using ErrorOr;
using FluentResults;
using OneOf;
using RestApiDDDArchitecture.Application.Common.Errors;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Domain.Common.Errors;
using RestApiDDDArchitecture.Domain.UserAggregate;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;
	public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
	}
	

	public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
	{

		// 1. Validate the user doesnt exist
		if (_userRepository.GetUserByEmail(email) is not null)
		{
			//// regular execption throwing
			// throw new Exception("User with given email already exist");

			//-------------------------------------

			//// custom exception throwing
			// throw new DuplicateEmailException();

			//-------------------------------------

			//// using oneOf package
			// return new DuplicateEmailError(); // different way of doing the above things, this one is using a "oneOf" package,
												 // where it can return different things based on an outcome
												 // this is for the OneOf package where we use OneOf<AuthenticationResult, DuplicateEmailError> Register

			//-------------------------------------

			//// using fluentResults package
			//return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() }); // using fluentResults package we can return a list of errors
																							 //  Result<AuthenticationResult> Register

			//-------------------------------------																			   

			//// using errorOr package
			return Errors.User.DuplicateEmail;

		}

		// 2. Create user(generate unique ID) & persist to DB
		var user = User.Create(firstName, lastName, email, password);
		
		_userRepository.Add(user);
		// 3. Create JWT token

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}
