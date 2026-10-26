using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Simionica_Alin_Laborator2.Models;
using Simionica_Alin_Laborator2.ViewModels;

namespace Simionica_Alin_Laborator2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Simionica_Alin_Laborator2Context _context;

    public IndexModel(Simionica_Alin_Laborator2Context context)
    {
        _context = context;
    }

    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();
        CategoryData.Categories = await _context.Category
            .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            Category category = CategoryData.Categories
                .Where(c => c.ID == id.Value).Single();
            CategoryData.Books = category.BookCategories.Select(bc => bc.Book);
        }
    }
}