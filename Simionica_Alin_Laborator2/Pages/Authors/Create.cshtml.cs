using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.Authors;

public class CreateModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;
    public CreateModel(Simionica_Alin_Laborator2Context context) { _context = context; }

    public IActionResult OnGet() { return Page(); }

    [BindProperty]
    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Author.Add(Author);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
