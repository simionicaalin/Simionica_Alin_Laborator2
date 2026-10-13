using Microsoft.EntityFrameworkCore;

public class Simionica_Alin_Laborator2Context(DbContextOptions<Simionica_Alin_Laborator2Context> options) : DbContext(options)
{
    public DbSet<Simionica_Alin_Laborator2.Models.Book> Book { get; set; } = default!;
    public DbSet<Simionica_Alin_Laborator2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Simionica_Alin_Laborator2.Models.Author> Author { get; set; } = default!;
}
