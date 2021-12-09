using System;
using GitLabWebhook.Requests;
using Newtonsoft.Json.Linq;

namespace GitLabWebhook.JsonConverter;

public class GitLabWebhookJsonConverter : JsonCreationConverter<EventRequest>
{
    protected override EventRequest Create(Type objectType, JObject jObject)
    {
        if (jObject == null) throw new ArgumentNullException(nameof(jObject));

        return jObject["object_kind"]?.Value<string>() switch
        {
            // Push event
            "push" => new Push(),

            // Comment event
            "note" => new Note(),

            // Null event
            _ => new EventRequest()
        };
    }
}