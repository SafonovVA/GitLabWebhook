using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Requests;

public abstract class EventRequest
{
    [Required]
    [JsonPropertyName("object_kind")]
    public string ObjectKind { get; set; }
}