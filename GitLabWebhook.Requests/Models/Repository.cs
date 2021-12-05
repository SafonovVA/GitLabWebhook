using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Models;

public class Repository
{
    public string Name { get; set; }

    public string Url { get; set; }
    
    public string Description { get; set; }

    [Url]
    public string Homepage { get; set; }
    
    [Url]
    [JsonPropertyName("git_http_url")]
    public string GitHTTPUrl { get; set; }
    
    [JsonPropertyName("git_SSH_url")]
    public string GitSSHUrl { get; set; }
    
    public int VisibilityLevel { get; set; }
}