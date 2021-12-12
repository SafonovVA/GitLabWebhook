using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GitLabWebhook.Data.Models;

public class Project
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Remote("IsProjectIdExists", "Project", AdditionalFields = "Id", ErrorMessage = "Id already exist.")]
    public int ProjectId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}