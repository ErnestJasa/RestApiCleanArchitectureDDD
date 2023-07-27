using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RestApiDDDArchitecture.Api.Controllers;

public class ErrorsController : ControllerBase
{
	[Route("/error")]
	public IActionResult Error()
	{
		Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        /*
		// var (statusCode, message) = exception switch{
		// 	DuplicateEmailException =>(StatusCodes.Status409Conflict, "Email already exists"),
		// 	_ => (StatusCodes.Status500InternalServerError, "An unexpected error occured."),
		// };
		var (statusCode, message) = exception switch // pretty much the same as above just more universal and less hard coded. 
													 //	Different errors can implement the interface in their own way, with their own message
		{
			IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
			_ => (StatusCodes.Status500InternalServerError, "An unexpected error occured"),
		};
		
		return Problem(statusCode: statusCode, title: message);
		*/

        return Problem(title: exception?.Message, statusCode: 400);
	}
}