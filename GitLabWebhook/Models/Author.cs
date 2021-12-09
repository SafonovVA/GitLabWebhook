using System.ComponentModel.DataAnnotations;

namespace GitLabWebhook.Models;

public class Author
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}