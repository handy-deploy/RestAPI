namespace Persistence;

public static class EnvironmentSettings
{
    public static string? PostgresConnectionString { get; private set; }
    public static string? GithubClientId { get; private set; }
    public static string? GithubClientSecret { get; private set; }

    public static void FetchEnvironmentVariables()
    {
        PostgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
        if (PostgresConnectionString == null)
            throw new ApplicationException("No POSTGRES_CONNECTION_STRING was supplied");

        GithubClientId = Environment.GetEnvironmentVariable("GITHUB_CLIENT_ID");
        if (GithubClientId == null)
            throw new ApplicationException("No GITHUB_CLIENT_ID was supplied");

        GithubClientSecret = Environment.GetEnvironmentVariable("GITHUB_CLIENT_SECRET");
        if(GithubClientSecret == null)
            throw new ApplicationException("No GITHUB_CLIENT_SECRET was supplied");
    }
}