using Simionica_Alin_Laborator2.Models;

namespace Simionica_Alin_Laborator2.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}