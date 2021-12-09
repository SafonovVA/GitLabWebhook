using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class Project
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    
    [Required]
    [Url]
    [JsonProperty("web_url")]
    public string? WebUrl { get; set; }
    
    [Url]
    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }
    
    [Required]
    [JsonProperty("git_ssh_url")]
    public string? GitSshUrl { get; set; }
    
    [Required]
    [Url]
    [JsonProperty("git_http_url")]
    public string? GitHttpUrl { get; set; }
    
    [Required]
    public string? Namespace { get; set; }
    
    [Required]
    [JsonProperty("visibility_level")]
    public int VisibilityLevel { get; set; }
    
    [Required]
    [JsonProperty("path_with_namespace")]
    public string? PathWithNamespace { get; set; }
    
    [Required]
    [JsonProperty("default_branch")]
    public string? DefaultBranch { get; set; }
    
    [Required]
    [Url]
    public string? Homepage { get; set; }
    
    [Required]
    public string? Url { get; set; }
    
    [Required]
    [JsonProperty("ssh_url")]
    public string? SshUrl { get; set; }
    
    [Required]
    [Url]
    [JsonProperty("http_url")]
    public string? HttpUrl { get; set; }
}