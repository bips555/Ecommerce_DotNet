using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
    }
}
