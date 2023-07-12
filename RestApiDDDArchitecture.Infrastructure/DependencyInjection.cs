using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Application.Common.Interfaces.Services;
using RestApiDDDArchitecture.Infrastructure.Authentication;
using RestApiDDDArchitecture.Infrastructure.Persistence;
using RestApiDDDArchitecture.Infrastructure.Services;


namespace RestApiDDDArchitecture.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
		return services;
	}
}