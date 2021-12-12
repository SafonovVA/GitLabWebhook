using System.ComponentModel.DataAnnotations;
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
    [MaxLength(50)]
    public string Name { get; set; }
}