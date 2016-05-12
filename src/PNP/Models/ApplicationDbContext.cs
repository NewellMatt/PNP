using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace PNP.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Story> Stories { get; set; }
    }
}
