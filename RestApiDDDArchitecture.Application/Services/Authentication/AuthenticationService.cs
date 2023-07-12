using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
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
	public AuthenticationResult Login(string email, string password)
	{
		// 1. Validate the user exists
		if (_userRepository.GetUserByEmail(email) is not User user)
		{
			throw new Exception("User with given email does not exist");
		}
		// 2. Validate the password is correct
		if (user.Password != password)
		{
			throw new Exception("Invalid password.");
		}


		// 3. generate JWT token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(
			user,
			token
		);
	}

	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{

		// 1. Validate the user doesnt exist
		if (_userRepository.GetUserByEmail(email) is not null)
		{
			throw new Exception("User with given email already exist");
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