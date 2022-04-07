using System;
using System.ComponentModel.DataAnnotations;

namespace GitLabWebhook.Models;

public class Commit
{
    [Required]
    public string? Id { get; set; }

    [Required]
    public string? Message { get; set; }

    public string? Title { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    [Url]
    public string? Url { get; set; }

    public Author? Author { get; set; }

    public string[] Added { get; set; } = Array.Empty<string>();

    public string[] Modified { get; set; } = Array.Empty<string>();

    public string[] Removed { get; set; } = Array.Empty<string>();
}