using GitLabWebhook.Requests;
using Newtonsoft.Json.Linq;

namespace GitLabWebhook.JsonConverter;

public class GitLabWebhookJsonConverter : JsonCreationConverter<EventRequest>
{
    protected override EventRequest Create(Type objectType, JObject jObject)
    {
        if (jObject == null) throw new ArgumentNullException(nameof(jObject));

        if (jObject["object_kind"]?.Value<string>() == "push")
        {
            return new Push();
        }
        if (jObject["object_kind"]?.Value<string>() == "note")
        {
            return new Note();
        }
        

        return new EventRequest();
    }
}