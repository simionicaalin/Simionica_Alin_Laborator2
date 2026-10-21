using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.CategoryPages;

public class DetailsModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;
    public DetailsModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
        if (category is null)
        {
            return NotFound();
        }
        else
        {
            Category = category;
        }

        return Page();
    }
}
