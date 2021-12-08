using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;

public class ObjectAttributes
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Note { get; set; }
    
    [Required]
    [JsonProperty("noteable_type")]
    public string NoteAbletype { get; set; }
    
    [Required]
    [JsonProperty("author_id")]
    public int AuthorId { get; set; }
    
    
    [Required]
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [Required]
    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }
    
    [Required]
    [JsonProperty("project_id")]
    public int ProjectId { get; set; }
    
    [JsonProperty("attachment")] 
    public string? Attachment { get; set; } = string.Empty;
    
    [Required]
    [JsonProperty("line_code")]
    public string LineCode { get; set; }
    
    [Required]
    [JsonProperty("commit_id")]
    public string CommitId { get; set; }

    [JsonProperty("noteable_id")] 
    public string? NoteableId { get; set; } = string.Empty;
    
    [Required]
    public bool System { get; set; }
    
    [Required]
    [JsonProperty("st_diff")]
    public StDiff StDiff { get; set; }
    
    [Required]
    [Url]
    public string Url { get; set; }
}