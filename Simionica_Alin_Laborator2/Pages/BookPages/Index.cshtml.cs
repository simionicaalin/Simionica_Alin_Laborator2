using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public IndexModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public int? AuthorID { get; set; }

    public SelectList Authors { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Authors = new SelectList(await _context.Author.ToListAsync(), "ID", "FullName");

        var query = _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .AsQueryable();

        if (AuthorID.HasValue)
        {
            query = query.Where(b => b.AuthorID == AuthorID);
        }

        Book = await query.ToListAsync();
    }
}
