﻿using Ecommerce_DataAccess.Data;
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
        private ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(ApplicationUser applicationUser)
        {
           _context.ApplicationUsers.Update(applicationUser);
        }
    }
}
