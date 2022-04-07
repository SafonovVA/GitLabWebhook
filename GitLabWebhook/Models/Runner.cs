using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class Runner
{
    public int? Id { get; set; }
    
    public string? Description { get; set; }

    public bool? Active { get; set; }
    
    [JsonProperty("runner_type")]
    public string? RunnerType { get; set; }
    
    [JsonProperty("is_shared")]
    public bool? IsShared { get; set; }

    public string[]? Tags { get; set; }
}

/*
{
    "id": 380987,
    "description": "shared-runners-manager-6.gitlab.com",
    "active": true,
    "runner_type": "instance_type",
    "is_shared": true,
    "tags": [
      "linux",
      "docker",
      "shared-runner"
    ]
}
*/