using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.MemberPages;

public class DeleteModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public DeleteModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Member Member { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
        if (member is null)
        {
            return NotFound();
        }
        else
        {
            Member = member;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var member = await _context.Member.FindAsync(id);
        if (member != null)
        {
            Member = member;
            _context.Member.Remove(Member);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
