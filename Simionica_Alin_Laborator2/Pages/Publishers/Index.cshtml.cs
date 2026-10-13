using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.Publishers;

public class IndexModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;
    public IndexModel(Simionica_Alin_Laborator2Context context) { _context = context; }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
