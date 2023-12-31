using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestApiDDDArchitecture.Application.Common.Interfaces.Authentication;
using RestApiDDDArchitecture.Application.Common.Interfaces.Persistence;
using RestApiDDDArchitecture.Application.Common.Interfaces.Services;
using RestApiDDDArchitecture.Infrastructure.Authentication;
using RestApiDDDArchitecture.Infrastructure.Persistence;
using RestApiDDDArchitecture.Infrastructure.Persistence.Interceptors;
using RestApiDDDArchitecture.Infrastructure.Persistence.Repositories;
using RestApiDDDArchitecture.Infrastructure.Services;


namespace RestApiDDDArchitecture.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		services.AddAuth(configuration)
			  	.AddPersistance();
		
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
		return services;
	}
	
	
	public static IServiceCollection AddPersistance(
		this IServiceCollection services)
	{
		services.AddDbContext<AppDbContext>(options => 
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RestApiCleanArchitecture;TrustServerCertificate=true"));
			
		services.AddScoped<PublishDomainEventsInterceptor>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IMenuRepository, MenuRepository>();
		
		return services;
	}
	
	public static IServiceCollection AddAuth(
		this IServiceCollection services,
		ConfigurationManager configuration)
	{
		var jwtSettings = new JwtSettings();
		configuration.Bind(JwtSettings.SectionName, jwtSettings);
		services.AddSingleton(Options.Create(jwtSettings)); // these three lines is the same as the one below
		//services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
		services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
		
		services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtSettings.Issuer,
						ValidAudience = jwtSettings.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
					});
		
		return services;		
	}
}