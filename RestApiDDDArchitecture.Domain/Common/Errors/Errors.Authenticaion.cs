using ErrorOr;

namespace RestApiDDDArchitecture.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials = Error.Validation(
        	code: "Auth.InvalidCredentials",
        	description: "Invalid credentials");
    }
}