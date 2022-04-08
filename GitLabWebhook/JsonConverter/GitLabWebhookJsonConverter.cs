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
            "push" => new Push(),
            "tag_push" => new Tag(),
            "note" => new Note(),
            "issue" => new Issue(),
            "merge_request" => new Requests.MergeRequest(),
            "pipeline" => new Pipeline(),
            "build" => new Job(),
            "deployment" => new Deployment(),
            _ => new EventRequest()
        };
    }
}