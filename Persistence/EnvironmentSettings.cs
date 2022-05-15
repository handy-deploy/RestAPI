namespace Persistence;

public static class EnvironmentSettings
{
    public static string? PostgresConnectionString { get; set; }

    public static void FetchEnvironmentVariables()
    {
        PostgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

        if (PostgresConnectionString == null)
            throw new ApplicationException("No POSTGRES_CONNECTION_STRING was supplied");
    }
}