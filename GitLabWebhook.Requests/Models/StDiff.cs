using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GitLabWebhook.Requests.Models;

public class StDiff
{
    [Required]
    public string Diff { get; set; }
    
    [Required]
    [JsonPropertyName("new_path")]
    public string NewPath { get; set; }
    
    [Required]
    [JsonPropertyName("old_path")]
    public string OldPath { get; set; }
    
    [Required]
    [JsonPropertyName("a_mode")]
    public int AMode { get; set; }
    
    [Required]
    [JsonPropertyName("b_mode")]
    public int BMode { get; set; }
    
    [Required]
    [JsonPropertyName("new_file")]
    public bool NewFile { get; set; }
    
    [Required]
    [JsonPropertyName("renamed_file")]
    public bool RenamedFile { get; set; }
    
    [Required]
    [JsonPropertyName("deleted_file")]
    public bool DeletedFile { get; set; }
}