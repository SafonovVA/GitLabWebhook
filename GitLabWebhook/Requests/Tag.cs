using System.ComponentModel.DataAnnotations;
using GitLabWebhook.Models;
using Newtonsoft.Json;

namespace GitLabWebhook.Requests;

public class Tag : EventRequest
{
    [Required]
    [JsonProperty("event_name")]
    public string? EventName { get; set; }

    [Required]
    public string? Before { get; set; }

    [Required]
    public string? After { get; set; }

    [Required]
    public string? Ref { get; set; }

    [Required]
    [JsonProperty("checkout_sha")]
    public string? CheckoutSha { get; set; }

    [Required]
    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [Required]
    [JsonProperty("user_name")]
    public string? UserName { get; set; }

    [Required]
    [Url]
    [JsonProperty("user_avatar")]
    public string? UserAvatar { get; set; }

    [Required]
    [JsonProperty("project_id")]
    public int ProjectId { get; set; }

    [Required]
    public Project? Project { get; set; }

    [Required]
    public Repository? Repository { get; set; }

    [Required]
    public Commit[] Commits { get; set; } = Array.Empty<Commit>();

    [Required]
    public int TotalCommitsCount { get; set; }

    public override string ToString()
    {
        var message = $"<b>Tag Push</b> from <u>{UserName}</u> with commits:\n";

        var i = 1;
        return Commits.Aggregate(message, (current, commit) =>
            current + $"{i++}) <a href=\"{commit.Url}\">{commit.Title}</a>\n");
    }
}
/*
  {
  "object_kind": "tag_push",
  "event_name": "tag_push",
  "before": "0000000000000000000000000000000000000000",
  "after": "82b3d5ae55f7080f1e6022629cdb57bfae7cccc7",
  "ref": "refs/tags/v1.0.0",
  "checkout_sha": "82b3d5ae55f7080f1e6022629cdb57bfae7cccc7",
  "user_id": 1,
  "user_name": "John Smith",
  "user_avatar": "https://s.gravatar.com/avatar/d4c74594d841139328695756648b6bd6?s=8://s.gravatar.com/avatar/d4c74594d841139328695756648b6bd6?s=80",
  "project_id": 1,
  "project":{
    "id": 1,
    "name":"Example",
    "description":"",
    "web_url":"http://example.com/jsmith/example",
    "avatar_url":null,
    "git_ssh_url":"git@example.com:jsmith/example.git",
    "git_http_url":"http://example.com/jsmith/example.git",
    "namespace":"Jsmith",
    "visibility_level":0,
    "path_with_namespace":"jsmith/example",
    "default_branch":"master",
    "homepage":"http://example.com/jsmith/example",
    "url":"git@example.com:jsmith/example.git",
    "ssh_url":"git@example.com:jsmith/example.git",
    "http_url":"http://example.com/jsmith/example.git"
  },
  "repository":{
    "name": "Example",
    "url": "ssh://git@example.com/jsmith/example.git",
    "description": "",
    "homepage": "http://example.com/jsmith/example",
    "git_http_url":"http://example.com/jsmith/example.git",
    "git_ssh_url":"git@example.com:jsmith/example.git",
    "visibility_level":0
  },
  "commits": [],
  "total_commits_count": 0
}*/