using Mapster;
using RestApiDDDArchitecture.Application.Authentication.Commands.Register;
using RestApiDDDArchitecture.Application.Authentication.Queries.Login;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Contracts.Authentication;

namespace RestApiDDDArchitecture.Api.Common.Mapping;

public class AuthenticaionMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<RegisterRequest, RegisterCommand>();
		
		config.NewConfig<LoginRequest, LoginQuery>();
		
		config.NewConfig<AuthenticationResult, AuthenticationResponse>()
			.Map(dest => dest, src => src.User);
		
	}
}