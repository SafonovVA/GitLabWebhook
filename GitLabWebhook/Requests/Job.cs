using System.ComponentModel.DataAnnotations;
using GitLabWebhook.Models;
using Newtonsoft.Json;
using Environment = GitLabWebhook.Models.Environment;

namespace GitLabWebhook.Requests;

public class Job : EventRequest
{
    [JsonProperty("object_kind")]
    public string? ObjectKind { get; set; }
  
    public string? Ref { get; set; }
    
    public bool? Tag { get; set; }
    
    public string? Sha { get; set; }
    
    [JsonProperty("before_sha")]
    public string? BeforeSha { get; set; }
    
    [JsonProperty("build_id")]
    public int? BuildId { get; set; }
    
    [JsonProperty("build_name")]
    public string? BuildName { get; set; }
    
    [JsonProperty("build_stage")]
    public string? BuildStage { get; set; }
    
    [JsonProperty("build_status")]
    public string? BuildStatus { get; set; }
    
    [JsonProperty("build_created_at")]
    public DateTime? BuildCreatedAt { get; set; }
    
    [JsonProperty("build_started_at")]
    public DateTime? BuildStartedAt { get; set; }
    
    [JsonProperty("build_finished_at")]
    public DateTime? BuildFinishedAt { get; set; }
    
    [JsonProperty("build_duration")]
    public string? BuildDuration { get; set; }
    
    [JsonProperty("build_allow_failure")]
    public bool? BuildAllowFailure { get; set; }
    
    [JsonProperty("build_failure_reason")]
    public string? BuildFailureReason { get; set; }
    
    [JsonProperty("pipeline_id")]
    public int? PipelineId { get; set; }
    
    [JsonProperty("project_id")]
    public int? ProjectId { get; set; }
    
    [JsonProperty("project_name")]
    public string? ProjectName { get; set; }
    
    public User User { get; set; } = new User();

    public Commit? Commit { get; set; }
    
    public Repository? Repository { get; set; }
    
    public Runner? Runner { get; set; }
    
    public Environment? Environment { get; set; }

    public override string ToString()
    {
        var message = $"<b>Job</b> from <u>{User.Name}</u>\n";

        return message;
    }
}
/*
{
  "object_kind": "build",
  "ref": "gitlab-script-trigger",
  "tag": false,
  "before_sha": "2293ada6b400935a1378653304eaf6221e0fdb8f",
  "sha": "2293ada6b400935a1378653304eaf6221e0fdb8f",
  "build_id": 1977,
  "build_name": "test",
  "build_stage": "test",
  "build_status": "created",
  "build_created_at": "2021-02-23T02:41:37.886Z",
  "build_started_at": null,
  "build_finished_at": null,
  "build_duration": null,
  "build_allow_failure": false,
  "build_failure_reason": "script_failure",
  "pipeline_id": 2366,
  "project_id": 380,
  "project_name": "gitlab-org/gitlab-test",
  "user": {
    "id": 3,
    "name": "User",
    "email": "user@gitlab.com",
    "avatar_url": "http://www.gravatar.com/avatar/e32bd13e2add097461cb96824b7a829c?s=80\u0026d=identicon"
  },
  "commit": {
    "id": 2366,
    "sha": "2293ada6b400935a1378653304eaf6221e0fdb8f",
    "message": "test\n",
    "author_name": "User",
    "author_email": "user@gitlab.com",
    "status": "created",
    "duration": null,
    "started_at": null,
    "finished_at": null
  },
  "repository": {
    "name": "gitlab_test",
    "description": "Atque in sunt eos similique dolores voluptatem.",
    "homepage": "http://192.168.64.1:3005/gitlab-org/gitlab-test",
    "git_ssh_url": "git@192.168.64.1:gitlab-org/gitlab-test.git",
    "git_http_url": "http://192.168.64.1:3005/gitlab-org/gitlab-test.git",
    "visibility_level": 20
  },
  "runner": {
    "active": true,
    "runner_type": "project_type",
    "is_shared": false,
    "id": 380987,
    "description": "shared-runners-manager-6.gitlab.com",
    "tags": [
      "linux",
      "docker"
    ]
  },
  "environment": null
}
*/