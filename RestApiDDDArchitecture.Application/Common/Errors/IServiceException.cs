using System.Net;

namespace RestApiDDDArchitecture.Application.Common.Errors;

public interface IServiceException		// interface used to implement custom errors.
{
	public HttpStatusCode StatusCode { get; }
	public string ErrorMessage { get; }
}