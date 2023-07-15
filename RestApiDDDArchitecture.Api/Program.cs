using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestApiDDDArchitecture.Api;
using RestApiDDDArchitecture.Api.Common.Errors;
using RestApiDDDArchitecture.Api.Filters;
using RestApiDDDArchitecture.Application;
using RestApiDDDArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddPresentation()
		.AddApplication()
		.AddInfrastructure(builder.Configuration);		
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
