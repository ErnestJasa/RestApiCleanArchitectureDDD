using RestApiDDDArchitecture.Application.Common.Interfaces.Services;

namespace RestApiDDDArchitecture.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}