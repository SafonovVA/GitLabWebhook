using System.ComponentModel.DataAnnotations;

namespace GitLabWebhook.Requests.Models;

public class Commit
{
  [Required]
  public string Id { get; set; }
  
  [Required]
  public string Message { get; set; }
  
  [Required]
  public string Title { get; set; }
  
  [Required]
  public DateTime timestamp { get; set; }
  
  [Required]
  [Url]
  public string Url { get; set; }
  
  [Required]
  public Author Author { get; set; }
  
  [Required]
  public string[] Added { get; set; }
  
  [Required]
  public string[] Modified { get; set; }
  
  [Required]
  public string[] Removed { get; set; }
}