using ErrorOr;
using MediatR;
using RestApiDDDArchitecture.Application.Services.Authentication.Common;

namespace RestApiDDDArchitecture.Application.Authentication.Queries.Login;

public record LoginQuery(string Email,
                         string Password) : IRequest<ErrorOr<AuthenticationResult>>;