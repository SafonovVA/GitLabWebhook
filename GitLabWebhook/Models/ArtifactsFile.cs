using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class ArtifactsFile
{
    [JsonProperty("filename")]
    public string? FileName { get; set; }

    public string? Size { get; set; }
}

/*
{
  "filename": null,
  "size": null
}
*/