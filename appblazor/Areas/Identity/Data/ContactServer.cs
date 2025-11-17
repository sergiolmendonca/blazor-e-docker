using appblazor.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace appblazor.Data;

public class ContactService
{
    private readonly ApplicationDbContext _context;

    public ContactService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAll()
        => await _context.Contacts.ToListAsync();

    public async Task<Contact?> GetById(int id)
        => await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Add(Contact contact)
    {
        _context.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Contact contact)
    {
        _context.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var contact = await GetById(id);
        if (contact != null)
        {
            _context.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}