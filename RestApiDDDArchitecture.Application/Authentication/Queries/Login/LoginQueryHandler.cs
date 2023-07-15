using ErrorOr;
using MediatR;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Domain.Entities;
using RestApiDDDArchitecture.Domain.Common.Errors;


namespace RestApiDDDArchitecture.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;

	public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
	{
		_userRepository = userRepository;
		_jwtTokenGenerator = jwtTokenGenerator;
	}
	public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
		// 1. Validate the user exists
		if (_userRepository.GetUserByEmail(query.Email) is not User user)
		{
			//// regular exceptiont throwing
			// throw new Exception("User with given email does not exist");

			//// using errorOr
			return Errors.Authentication.InvalidCredentials;
		}
		// 2. Validate the password is correct
		if (user.Password != query.Password)
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
