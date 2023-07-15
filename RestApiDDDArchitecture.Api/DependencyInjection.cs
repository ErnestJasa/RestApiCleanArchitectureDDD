using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestApiDDDArchitecture.Api.Common.Errors;
using RestApiDDDArchitecture.Api.Common.Mapping;

namespace RestApiDDDArchitecture.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{

        //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());	// Error handling attribute
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, OurOwnProblemDetailsFactory>(); // overriding the problem details with out own implementation
        services.AddMappings();
		return services;
	}
}