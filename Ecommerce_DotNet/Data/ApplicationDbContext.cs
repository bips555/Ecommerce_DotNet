using Ecommerce_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
