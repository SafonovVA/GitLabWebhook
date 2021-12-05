using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Models;

public class Project
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    
    [Required]
    [Url]
    [JsonPropertyName("web_url")]
    public string WebUrl { get; set; }
    
    [Url]
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }
    
    [Required]
    [JsonPropertyName("git_ssh_url")]
    public string GitSSHUrl { get; set; }
    
    [Required]
    [Url]
    [JsonPropertyName("git_http_url")]
    public string GitHTTPUrl { get; set; }
    
    [Required]
    public string Namespace { get; set; }
    
    [Required]
    [JsonPropertyName("visibility_level")]
    public int VisibilityLevel { get; set; }
    
    [Required]
    [JsonPropertyName("path_with_namespace")]
    public string PathWithNamespace { get; set; }
    
    [Required]
    [JsonPropertyName("default_branch")]
    public string DefaultBranch { get; set; }
    
    [Required]
    [Url]
    public string Homepage { get; set; }
    
    [Required]
    public string Url { get; set; }
    
    [Required]
    [JsonPropertyName("ssh_url")]
    public string SSHUrl { get; set; }
    
    [Required]
    [Url]
    [JsonPropertyName("http_url")]
    public string HTTPUrl { get; set; }
}