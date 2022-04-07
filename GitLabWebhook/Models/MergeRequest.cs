using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class MergeRequest
{
    public int? Id { get; set; }

    public int? Iid { get; set; }
    
    public string? Title { get; set; }
    
    [JsonProperty("source_branch")]
    public string? SourceBranch { get; set; }
    
    [JsonProperty("source_project_id")]
    public int? SourceProjectId { get; set; }
    
    [JsonProperty("target_branch")]
    public string? TargetBranch { get; set; }
    
    [JsonProperty("target_project_id")]
    public int? TargetProjectId { get; set; }
    
    public string? State { get; set; }
    
    [JsonProperty("merge_status")]
    public string? MergeStatus { get; set; }
    [Required]
    [Url]
    public string? Url { get; set; }
}

/*
{
  "id": 1,
  "iid": 1,
  "title": "Test",
  "source_branch": "test",
  "source_project_id": 1,
  "target_branch": "master",
  "target_project_id": 1,
  "state": "opened",
  "merge_status": "can_be_merged",
  "url": "http://192.168.64.1:3005/gitlab-org/gitlab-test/merge_requests/1"
}
*/