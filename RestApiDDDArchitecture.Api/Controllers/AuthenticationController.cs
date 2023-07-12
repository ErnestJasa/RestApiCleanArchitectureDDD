using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using RestApiDDDArchitecture.Application.Common.Errors;
using RestApiDDDArchitecture.Application.Services.Authentication;
using RestApiDDDArchitecture.Contracts.Authentication;


namespace RestApiDDDArchitecture.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController 
{
	private readonly IAuthenticationService _authenticationService;
	public AuthenticationController(IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}
	[HttpPost("register")]
	public IActionResult Register(RegisterRequest request)
	{
		//// Implementation without error handling in this controller. Error handling is done in ErrorsController.
		// var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

		//-------------------------------------
		
		//// implementation using errorOr package
		ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
			request.FirstName,
			request.LastName,
			request.Email,
			request.Password);	
			return authResult.Match(
				authResult => Ok(MapAuthResult(authResult)),
				errors => Problem(errors)); // pass the list of errors to the method we created in the ApiController

		//-------------------------------------

		//// Implementation with error handling using fluentResult package
		// Result<AuthenticationResult> registerResult = _authenticationService.Register(
		// 	request.FirstName,
		// 	request.LastName,
		// 	request.Email,
		// 	request.Password);	

		// if(registerResult.IsSuccess)
		// {
		// 	return Ok(MapAuthResult(registerResult.Value));
		// }
		// var firstError = registerResult.Errors[0];
		// if(firstError is DuplicateEmailError)
		// {
		// 	return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already exists");
		// }
		// return Problem();


		//-------------------------------------

		//// Implementation with error handling using OneOf package
		// OneOf<AuthenticationResult, DuplicateEmailError> registerResult = _authenticationService.Register(
		// 	request.FirstName,
		// 	request.LastName,
		// 	request.Email,
		// 	request.Password);			
		// return registerResult.Match( // pretty much same as below just shortened. without the if and separate returns
		//     authResult => Ok(MapAuthResult(authResult)),
		// 	_ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists")); 
		// if (registerResult.IsT0)
		// {
		// 	var authResult = registerResult.AsT0;
		// 	AuthenticationResponse response = MapAuthResult(authResult);
		// 	return Ok(response);
		// }
		// return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists");
	}



	[HttpPost("login")]
	public IActionResult Login(LoginRequest request)
	{
		//// Implementation without error handling in this controller. Error handling is done in ErrorsController.
		//var authResult = _authenticationService.Login(request.Email, request.Password);
		//return Ok(response);
		// var response = new AuthenticationResponse(
		// 	authResult.User.Id,
		// 	authResult.User.FirstName,
		// 	authResult.User.LastName,
		// 	authResult.User.Email,
		// 	authResult.Token
		// );

		//-------------------------------------

		//// Implementation using errorOr

		ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email, request.Password);
		
		return authResult.Match(
			authResult => Ok(MapAuthResult(authResult)),
			errors => Problem(errors));	// same as register, we pass the errors to our ApiController
		
	}

	private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
	{
		return new AuthenticationResponse(
			authResult.User.Id,
			authResult.User.FirstName,
			authResult.User.LastName,
			authResult.User.Email,
			authResult.Token
		);
	}
}

