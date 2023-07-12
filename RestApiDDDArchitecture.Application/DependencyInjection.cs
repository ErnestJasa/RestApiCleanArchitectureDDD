using Microsoft.Extensions.DependencyInjection;
using RestApiDDDArchitecture.Application.Services.Authentication;

namespace RestApiDDDArchitecture.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<IAuthenticationService, AuthenticationService>();
		return services;
	}
}