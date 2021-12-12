using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Project> Projects { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}
    
    
    
    
    //public DbSet<TodoItem> TodoItems { get; set; } = null!;
}