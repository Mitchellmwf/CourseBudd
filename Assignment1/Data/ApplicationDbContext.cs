using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseBudd.Models;

namespace CourseBudd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CourseBudd.Models.Module> Module { get; set; } = default!;
        public DbSet<CourseBudd.Models.Subject> Subject { get; set; } = default!;
    }
}
