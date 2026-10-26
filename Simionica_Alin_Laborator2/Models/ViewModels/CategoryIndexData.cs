using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}