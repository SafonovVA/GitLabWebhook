using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Models;

public class ObjectAttributes
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int Note { get; set; }
    
    [Required]
    [JsonPropertyName("noteable_type")]
    public int NoteAbletype { get; set; }
    
    [Required]
    [JsonPropertyName("author_id")]
    public int AuthorId { get; set; }
    
    [Required]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [Required]
    [JsonPropertyName("project_id")]
    public int ProjectId { get; set; }
    
    [Required]
    public string Attachment { get; set; }
    
    [Required]
    [JsonPropertyName("line_code")]
    public string LineCode { get; set; }
    
    [Required]
    [JsonPropertyName("commit_id")]
    public string CommitId { get; set; }
    
    [Required]
    [JsonPropertyName("noteable_id")]
    public string NoteableId { get; set; }
    
    [Required]
    public bool System { get; set; }
    
    [Required]
    [JsonPropertyName("st_diff")]
    public StDiff StDiff { get; set; }
    
    [Required]
    [Url]
    public StDiff Url { get; set; }
}