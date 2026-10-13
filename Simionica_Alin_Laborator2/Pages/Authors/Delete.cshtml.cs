using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.Authors;

public class DeleteModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;
    public DeleteModel(Simionica_Alin_Laborator2Context context) { _context = context; }

    [BindProperty]
    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return NotFound();
        var item = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
        if (item is null) return NotFound();
        Author = item;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null) return NotFound();
        // Include(Books) ca sa se seteze automat FK-ul cartilor pe NULL, altfel stergerea pica
        var item = await _context.Author.Include(e => e.Books).FirstOrDefaultAsync(e => e.ID == id);
        if (item != null)
        {
            _context.Author.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}
