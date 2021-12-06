using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GitLabWebhook.Requests.Models;

namespace GitLabWebhook.Requests.Requests;

public class Push : IEventRequest
{
    [Required]
    [JsonPropertyName("object_kind")]
    public string ObjectKind { get; set; }

    [Required]
    [JsonPropertyName("event_name")]
    public string EventName { get; set; }
    
    [Required]
    public string Before { get; set; }
    
    [Required]
    public string After { get; set; }
    
    [Required]
    public string Ref { get; set; }
    
    [Required]
    [JsonPropertyName("checkout_sha")]
    public string CheckoutSha { get; set; }
    
    [Required]
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    
    [Required]
    [JsonPropertyName("user_name")]
    public string UserName { get; set; }
    
    [Required]
    [JsonPropertyName("user_username")]
    public string UserUserName { get; set; }
    
    [Required]
    [JsonPropertyName("user_email")]
    public string UserEmail { get; set; }
    
    [Required]
    [Url]
    [JsonPropertyName("user_avatar")]
    public string UserAvatar { get; set; }
    
    [Required]
    [JsonPropertyName("project_id")]
    public int ProjectId { get; set; }
    
    [Required]
    public Project Project { get; set; }
    
    [Required]
    public Repository Repository { get; set; }
    
    [Required]
    public Commit[] Commits { get; set; }
    
    [Required]
    public int TotalCommitsCount { get; set; }
}