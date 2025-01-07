using Ecommerce_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_DataAccess.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category category);
        void Save();

    }
}
