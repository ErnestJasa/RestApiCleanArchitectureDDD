using System.Net;

namespace RestApiDDDArchitecture.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException     // an example of the custom IServiceException interface implementation
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists";
}