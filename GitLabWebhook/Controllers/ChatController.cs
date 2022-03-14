using GitLabWebhook.Data;
using GitLabWebhook.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitLabWebhook.Controllers;

public class ChatController : Controller
{
    private readonly ChatRepository _chatRepository;

    public ChatController(ApplicationDbContext context)
    {
        _chatRepository = new ChatRepository(context);
    }
    public async Task<ActionResult> Index()
    {
        return View(await _chatRepository.ToListAsync());
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    public async Task<ActionResult> Show(int id)
    {
        try
        {
            return View(await _chatRepository.FindByIdAsync(id));
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }    }
    
    public async Task<ActionResult> Edit(int id)
    {
        try
        {
            return View(await _chatRepository.FindByIdAsync(id));
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
    }
    
    public async Task<ActionResult> Destroy(int id)
    {
        try
        {
            await _chatRepository.DestroyAsync(id);
            return RedirectToAction(nameof(Index));        
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
    }
    
    public async Task<IActionResult> Store([Bind("ChatId,Name")] Chat chatData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Create), chatData);
        }
        
        await _chatRepository.CreateAsync(chatData);
        
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Update(int id, [Bind("ChatId,Name")] Chat chatData)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Edit), chatData);
        }

        try
        {
            await _chatRepository.UpdateAsync(id, chatData);
        }
        catch (NullReferenceException)
        {
            return NotFound();
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    public JsonResult IsChatIdExists(int chatId, int? id)
    {
        return Json(!_chatRepository.IsChatIdExists(chatId, id));
    }
}