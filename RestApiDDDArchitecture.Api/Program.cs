using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestApiDDDArchitecture.Api.Errors;
using RestApiDDDArchitecture.Api.Filters;
using RestApiDDDArchitecture.Application;
using RestApiDDDArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddApplication()
		.AddInfrastructure(builder.Configuration);
		
	//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());	// Error handling attribute
	builder.Services.AddControllers();
	
	builder.Services.AddSingleton<ProblemDetailsFactory, OurOwnProblemDetailsFactory>(); // overriding the problem details with out own implementation
}																	

// Add services to the container.


var app = builder.Build();

{
	//app.UseMiddleware<ErrorHandlingMiddleware>(); // Error handling middleware
	app.UseExceptionHandler("/error");	// pretty same thing as above just need to create a controller
	app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}
