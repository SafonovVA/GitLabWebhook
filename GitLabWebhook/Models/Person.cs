using GitLabWebhook.JsonConverter;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

[JsonConverter(typeof(PersonJsonConverter))] 
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Kind { get; set; }
    
    
}
