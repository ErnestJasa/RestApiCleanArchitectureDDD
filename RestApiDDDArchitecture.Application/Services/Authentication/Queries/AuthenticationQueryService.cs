using ErrorOr;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Domain.Common.Errors;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Domain.User;

namespace RestApiDDDArchitecture.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;
	public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
}