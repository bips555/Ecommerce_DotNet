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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(Category category)
        {
           _context.Categories.Update(category);
        }
    }
}
