using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.MemberPages;

public class CreateModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public CreateModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Member Member { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Member.Add(Member);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
