using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class Environment
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Action { get; set; }
    
    [Required]
    [JsonProperty("deployment_tier")]
    public string? DeploymentTier { get; set; }
}

/*
{
   "name": "staging",
   "action": "start",
   "deployment_tier": "staging"
 }
*/