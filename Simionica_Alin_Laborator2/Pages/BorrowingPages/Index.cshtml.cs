using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.BorrowingPages;

public class IndexModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public IndexModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Borrowing != null)
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member)
                .ToListAsync();
        }
    }
}
