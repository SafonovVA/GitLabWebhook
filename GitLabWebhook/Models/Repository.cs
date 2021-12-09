using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;
public class Repository
{
    public string? Name { get; set; }

    public string? Url { get; set; }
    
    public string? Description { get; set; }

    [Url]
    public string? Homepage { get; set; }
    
    [JsonProperty("git_http_url")]
    public string? GitHttpUrl { get; set; }
    
    [JsonProperty("git_SSH_url")]
    public string? GitSshUrl { get; set; }
    
    public int VisibilityLevel { get; set; }
}