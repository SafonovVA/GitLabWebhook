using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class Build
{
    [Required]
    public int? Id { get; set; }
    
    [Required]
    public string? Stage { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Status { get; set; }

    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    [JsonProperty("started_at")]
    public string? StartedAt { get; set; }

    [JsonProperty("finished_at")]
    public string? FinishedAt { get; set; }

    [Required]
    public string? When { get; set; }
    
    [Required]
    public bool? Manual { get; set; }
    
    [Required]
    [JsonProperty("allow_failure")]
    public bool? AllowFailure { get; set; }

    [Required]
    public User? User { get; set; }

    public Runner? Runner { get; set; }

    [Required]
    [JsonProperty("artifacts_file")]
    public ArtifactsFile? ArtifactsFile { get; set; }

    public Environment? Environment { get; set; }
}

/*
{
   "id": 380,
   "stage": "deploy",
   "name": "production",
   "status": "skipped",
   "created_at": "2016-08-12 15:23:28 UTC",
   "started_at": null,
   "finished_at": null,
   "when": "manual",
   "manual": true,
   "allow_failure": false,
   "user":{
      "id": 1,
      "name": "Administrator",
      "username": "root",
      "avatar_url": "http://www.gravatar.com/avatar/e32bd13e2add097461cb96824b7a829c?s=80\u0026d=identicon",
      "email": "admin@example.com"
   },
   "runner": null,
   "artifacts_file":{
      "filename": null,
      "size": null
   },
   "environment": {
     "name": "production",
     "action": "start",
     "deployment_tier": "production"
   }
}
*/