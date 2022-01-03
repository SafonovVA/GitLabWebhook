namespace GitLabWebhook.Extensions;

public static class EnvironmentVariableExtensions
{
    public static string GetConnectionStringFromEnvironment(
        this IConfiguration configuration, string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"Environment variable '{name}' value is '{value}' (is null or empty)");
        }

        return value;
    }
}