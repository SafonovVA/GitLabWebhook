using GitLabWebhook.Data;
using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Controllers;

public class MigrationController : Controller
{
    private readonly ApplicationDbContext _context;

    public MigrationController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        await _context.Database.MigrateAsync();
        
        return Ok();
    }
}