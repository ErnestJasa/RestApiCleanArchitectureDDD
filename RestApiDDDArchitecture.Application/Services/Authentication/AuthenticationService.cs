using ErrorOr;
using FluentResults;
using OneOf;
using RestApiDDDArchitecture.Application.Common.Errors;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Domain.Common.Errors;
using RestApiDDDArchitecture.Domain.Entities;

namespace RestApiDDDArchitecture.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;
	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
	}
	public ErrorOr<AuthenticationResult> Login(string email, string password)
	{
		// 1. Validate the user exists
		if (_userRepository.GetUserByEmail(email) is not User user)
		{
			//// regular exceptiont throwing
			// throw new Exception("User with given email does not exist");
			
			//// using errorOr
			return Errors.Authentication.InvalidCredentials;
		}
		// 2. Validate the password is correct
		if (user.Password != password)
		{
            //// regular exceptiont throwing
            //throw new Exception("Invalid password.");

            //// using errorOr
            return new[] { Errors.Authentication.InvalidCredentials };
		}


		// 3. generate JWT token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(
			user,
			token
		);
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
		var user = new User
		{
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			Password = password
		};
		_userRepository.Add(user);
		// 3. Create JWT token

		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}
