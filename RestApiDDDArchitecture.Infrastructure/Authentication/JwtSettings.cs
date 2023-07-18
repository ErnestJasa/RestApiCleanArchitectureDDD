namespace RestApiDDDArchitecture.Infrastructure.Authentication;

public class JwtSettings
{
	// we define the structure in the appsettings.json file and
	// give values in the appsettings.Development.json file inside the api project
	public const string SectionName = "JwtSettings";	
	public string Secret { get; init; } = null!;
	public int ExpiryMinutes { get; init; }
	public string Issuer { get; init; } = null!;
	public string Audience { get; init; } = null!;
}