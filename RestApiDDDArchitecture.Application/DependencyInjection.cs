using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestApiDDDArchitecture.Application.Authentication.Commands.Register;
using RestApiDDDArchitecture.Application.Common.Behaviors;
using RestApiDDDArchitecture.Application.Services.Authentication.Commands;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Application.Services.Authentication.Queries;
using System.Reflection;

namespace RestApiDDDArchitecture.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		//// doing pretty much the same wiring with mediator as below with dependency injecting
		services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		// services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
		// services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
		
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); // implementing the line belove as generics
		// services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, ValidationBehavior>();
		
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		return services;
	}
}