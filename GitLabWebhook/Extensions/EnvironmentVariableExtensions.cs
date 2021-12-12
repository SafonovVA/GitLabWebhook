namespace GitLabWebhook.Extensions;

public static class EnvironmentVariableExtensions
{
    public static string GetConnectionStringFromEnvironment(
        this IConfiguration configuration, string name)
    {
        var variable = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrEmpty(variable))
        {
            throw new ArgumentException();
        }

        return variable;
    }
}