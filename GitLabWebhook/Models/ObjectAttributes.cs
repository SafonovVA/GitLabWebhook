using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class ObjectAttributes
{
    [Required]
    public int Id { get; set; }

    public string? Note { get; set; }

    [JsonProperty("noteable_type")]
    public string? NoteAbletype { get; set; }

    [JsonProperty("source_branch")]
    public string? SourceBranch { get; set; }

    [JsonProperty("target_branch")]
    public string? TargetBranch { get; set; }

    [Required]
    [JsonProperty("author_id")]
    public int AuthorId { get; set; }
    
    public string? Action { get; set; }
    
    [JsonProperty("before_sha")]
    public string? BeforeSha { get; set; }

    [Required]
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Required]
    [JsonProperty("project_id")]
    public int ProjectId { get; set; }

    [JsonProperty("attachment")]
    public string? Attachment { get; set; }

    [JsonProperty("line_code")]
    public string? LineCode { get; set; }

    [JsonProperty("commit_id")]
    public string? CommitId { get; set; }

    [JsonProperty("noteable_id")]
    public string? NoteableId { get; set; }

    [Required]
    public bool System { get; set; }

    [JsonProperty("st_diff")]
    public StDiff? StDiff { get; set; }

    public string? Url { get; set; } = string.Empty;
}