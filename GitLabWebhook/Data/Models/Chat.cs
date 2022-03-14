using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace GitLabWebhook.Data.Models;

public class Chat
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Remote("IsChatIdExists", "Chat", AdditionalFields = "Id", ErrorMessage = "Id already exist.")]
    public int ChatId { get; set; }
    
    [Required]
    [DisallowNull]
    [MaxLength(50)]
    public string? Name { get; set; }
    
    public ICollection<Project>? Projects { get; set; } 
}