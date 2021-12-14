using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
    [DisallowNull]
    [MaxLength(50)]
    public string? Name { get; set; }
}