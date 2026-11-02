using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options) : IdentityDbContext<Simionica_Alin_Laborator2.Data.ApplicationUser>(options)
{
}
