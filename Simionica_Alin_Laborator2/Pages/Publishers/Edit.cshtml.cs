using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.Publishers;

public class EditModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;
    public EditModel(Simionica_Alin_Laborator2Context context) { _context = context; }

    [BindProperty]
    public Publisher Publisher { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return NotFound();
        var item = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
        if (item is null) return NotFound();
        Publisher = item;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Attach(Publisher).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Publisher.Any(e => e.ID == Publisher.ID)) return NotFound();
            throw;
        }
        return RedirectToPage("./Index");
    }
}
