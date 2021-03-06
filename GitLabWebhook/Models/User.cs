using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? UserName { get; set; }

    [Required]
    [Url]
    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}