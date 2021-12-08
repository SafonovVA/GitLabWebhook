using System.ComponentModel.DataAnnotations;
using GitLabWebhook.JsonConverter;
using Newtonsoft.Json;

namespace GitLabWebhook.Requests;

[JsonConverter(typeof(GitLabWebhookJsonConverter))] 
public class EventRequest
{
    [Required]
    [JsonProperty("object_kind")]
    public string ObjectKind { get; set; }
}