using System.ComponentModel.DataAnnotations;

namespace GitLabWebhook.Models;

public class Variable
{
    public string? Key { get; set; }
    
    public string? Value { get; set; }
}