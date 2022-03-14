using Microsoft.EntityFrameworkCore;

namespace GitLabWebhook.Data.Models;

public class ChatRepository: Chat
{
    private readonly ApplicationDbContext _context;
    
    public ChatRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chat>> ToListAsync()
    {
        return await _context.Chats!.ToListAsync();
    }

    public async Task<Chat> FindByIdAsync(int id)
    {
        if (_context.Chats == null)
        {
            throw new NullReferenceException();
        }
        var chat = await _context.Chats
            .Include(chat => chat.Projects)
            .FirstAsync(chat => chat.Id == id);
        if (chat == null)
        {
            throw new NullReferenceException();
        }
        
        return chat;
    }

    public async Task DestroyAsync(int id)
    {
        var chat = await FindByIdAsync(id);
        if (_context.Chats == null)
        {
            throw new NullReferenceException();
        }
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
    }
    
    public async Task CreateAsync(Chat chatData)
    {
        _context.Add(new Chat
        {
            ChatId = chatData.ChatId,
            Name = chatData.Name!
        });
        
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(int id, Chat chatData)
    {
        try
        {
            var chat = await FindByIdAsync(id);
            chat.ChatId = chatData.ChatId;
            chat.Name = chatData.Name!;

            _context.Update(chat);
            await _context.SaveChangesAsync();
        }
        catch (NullReferenceException)
        {
            throw new NullReferenceException();
        }
    }

    public bool IsChatIdExists(int chatId, int? id)
    {
        return _context.Chats!.Any(x => x.ChatId == chatId && x.Id != id);
    }
}