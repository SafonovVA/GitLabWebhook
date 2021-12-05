using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Requests;

public interface IEventRequest
{
    public string EventName { get; set; }
}