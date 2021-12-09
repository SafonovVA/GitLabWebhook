using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class User
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? UserName { get; set; }
    
    [Required]
    [Url]
    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}