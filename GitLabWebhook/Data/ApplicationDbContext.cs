using System.Diagnostics.CodeAnalysis;
using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    [DisallowNull]
    public DbSet<Chat>? Chats { get; set; }

    [DisallowNull]
    public DbSet<Project>? Projects { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}
    
    
    
    
    //public DbSet<TodoItem> TodoItems { get; set; } = null!;
}