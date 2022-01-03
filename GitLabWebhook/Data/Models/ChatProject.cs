using System.Diagnostics.CodeAnalysis;

namespace GitLabWebhook.Data.Models;

public class ChatProject
{
    [DisallowNull]
    public Chat? Chat { get; set; }

    [DisallowNull]
    public Project? Project { get; set; }
}