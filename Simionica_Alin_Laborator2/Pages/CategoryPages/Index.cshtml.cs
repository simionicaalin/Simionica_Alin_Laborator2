using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public IndexModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
