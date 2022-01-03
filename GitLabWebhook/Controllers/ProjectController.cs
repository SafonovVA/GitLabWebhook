using GitLabWebhook.Data;
using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Controllers;

public class ProjectController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var projects = await _context.Projects!.ToListAsync();
        
        return View(projects);
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    public ActionResult Show(int projectId)
    {
        var project = _context.Projects!.Find(projectId);

        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }
    
    public ActionResult Edit(int id)
    {
        var project = _context.Projects!.Find(id);

        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }
    
    public ActionResult Destroy(int id)
    {
        var project = _context.Projects!.Find(id);

        if (project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Store([Bind("ProjectId,Name")] Project projectData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Create), projectData);
        }
        
        _context.Add(new Project
        {
            ProjectId = projectData.ProjectId,
            Name = projectData.Name!
        });
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id, [Bind("ProjectId,Name")] Project projectData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Edit), projectData);
        }

        var project = await _context.Projects!.FindAsync(id);

        if (project == null)
        {
            return NotFound();
        }
        
        project.ProjectId = projectData.ProjectId;
        project.Name = projectData.Name!;

        _context.Update(project);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
    public JsonResult IsProjectIdExists(int projectId, int? id)
    {
        return Json(!_context.Projects!.Any(x => x.ProjectId == projectId && x.Id != id));
    }
}