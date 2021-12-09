using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GitLabWebhook.Models;
public class StDiff
{
    [Required]
    public string? Diff { get; set; }
    
    [Required]
    [JsonProperty("new_path")]
    public string? NewPath { get; set; }
    
    [Required]
    [JsonProperty("old_path")]
    public string? OldPath { get; set; }
    
    [Required]
    [JsonProperty("a_mode")]
    public int AMode { get; set; }
    
    [Required]
    [JsonProperty("b_mode")]
    public int BMode { get; set; }
    
    [Required]
    [JsonProperty("new_file")]
    public bool NewFile { get; set; }
    
    [Required]
    [JsonProperty("renamed_file")]
    public bool RenamedFile { get; set; }
    
    [Required]
    [JsonProperty("deleted_file")]
    public bool DeletedFile { get; set; }
}