using ErrorOr;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using RestApiDDDArchitecture.Application.Authentication.Commands.Register;
using RestApiDDDArchitecture.Application.Authentication.Queries.Login;
using RestApiDDDArchitecture.Application.Common.Errors;
using RestApiDDDArchitecture.Application.Services.Authentication;
using RestApiDDDArchitecture.Application.Services.Authentication.Commands;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;
using RestApiDDDArchitecture.Application.Services.Authentication.Queries;
using RestApiDDDArchitecture.Contracts.Authentication;



namespace RestApiDDDArchitecture.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController 
{
	private readonly ISender _mediator; // mediator replaces the services below
	// private readonly IAuthenticationCommandService _authenticationCommandService;
	// private readonly IAuthenticationQueryService _authenticationQueryService;
	
	private readonly IMapper _mapper;
	public AuthenticationController(
		ISender mediator, // IAuthenticationCommandService authenticationCommandService,
						  // IAuthenticationQueryService authenticationQueryService
		IMapper mapper)
	{
		_mediator = mediator;
		// _authenticationCommandService = authenticationCommandService;
		// _authenticationQueryService = authenticationQueryService;
		_mapper = mapper;
	}
	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		//// Replacing services with mediator
		//var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
		var command = _mapper.Map<RegisterCommand>(request);
		
		//// Implementation without error handling in this controller. Error handling is done in ErrorsController.
		// var authResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

		//-------------------------------------

		//// implementation using errorOr package
		// ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
		// 	request.FirstName,
		// 	request.LastName,
		// 	request.Email,
		// 	request.Password);	
		ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
			return authResult.Match(
				authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
				errors => Problem(errors)); // pass the list of errors to the method we created in the ApiController

		//-------------------------------------

		//// Implementation with error handling using fluentResult package
		// Result<AuthenticationResult> registerResult = _authenticationCommandService.Register(
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
		// OneOf<AuthenticationResult, DuplicateEmailError> registerResult = _authenticationCommandService.Register(
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
	public async Task<IActionResult> Login(LoginRequest request)
	{
		//// Replacing services with mediator
		//var query = new LoginQuery(request.Email, request.Password);
		var query = _mapper.Map<LoginQuery>(request);
		
		//// Implementation without error handling in this controller. Error handling is done in ErrorsController.
		//var authResult = _authenticationQueryService.Login(request.Email, request.Password);
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
		// ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email, request.Password);
		ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);



		return authResult.Match(
			authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
			errors => Problem(errors));	// same as register, we pass the errors to our ApiController
		
	}	
}

