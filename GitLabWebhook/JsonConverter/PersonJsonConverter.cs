using GitLabWebhook.Models;
using Newtonsoft.Json.Linq;

namespace GitLabWebhook.JsonConverter;

public class PersonJsonConverter : JsonCreationConverter<Person>
{
    protected override Person Create(Type objectType, JObject jObject)
    {
        if (jObject == null) throw new ArgumentNullException(nameof(jObject));

        if (jObject["schoolName"] != null)
        {
            return new Student();
        }

        if (jObject["hospitalName"] != null)
        {
            return new Doctor();
        }

        return new Person();
    }
}