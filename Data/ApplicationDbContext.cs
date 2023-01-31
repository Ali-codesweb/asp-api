using bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace bookstore.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BooksModel> Book { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
    }
}
