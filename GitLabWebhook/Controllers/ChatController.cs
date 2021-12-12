using GitLabWebhook.Data;
using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Controllers;

public class ChatController : Controller
{
    private readonly ApplicationDbContext _context;

    public ChatController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var chats = await _context.Chats.ToListAsync();
        
        return View(chats);
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    public ActionResult Show(int chatId)
    {
        var chat = _context.Chats.Find(chatId);

        if (chat == null)
        {
            return NotFound();
        }
        return View(chat);
    }
    
    public ActionResult Edit(int id)
    {
        var chat = _context.Chats.Find(id);

        if (chat == null)
        {
            return NotFound();
        }
        return View(chat);
    }
    
    public ActionResult Destroy(int id)
    {
        var chat = _context.Chats.Find(id);

        if (chat == null)
        {
            return NotFound();
        }

        _context.Chats.Remove(chat);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Store([Bind("ChatId,Name")] Chat chatData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Create), chatData);
        }
        
        _context.Add(new Chat
        {
            ChatId = chatData.ChatId,
            Name = chatData.Name
        });
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id, [Bind("ChatId,Name")] Chat chatData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Edit), chatData);
        }

        var chat = await _context.Chats.FindAsync(id);

        if (chat == null)
        {
            return NotFound();
        }
        
        chat.ChatId = chatData.ChatId;
        chat.Name = chatData.Name;

        _context.Update(chat);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
    public JsonResult IsChatIdExists(int chatId, int? id)
    {
        return Json(!_context.Chats.Any(x => x.ChatId == chatId && x.Id != id));
    }
}