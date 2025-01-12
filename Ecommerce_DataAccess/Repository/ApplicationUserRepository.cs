using Ecommerce_DataAccess.Data;
using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

       
    }
}
