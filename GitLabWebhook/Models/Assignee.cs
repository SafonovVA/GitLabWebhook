using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class Assignee
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    [Url]
    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }
}