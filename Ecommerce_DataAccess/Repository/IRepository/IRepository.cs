using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity); 

        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null,bool tracked = false);
        void Remove(T entity);  
        void RemoveRange(IEnumerable<T> entities);
    }
}
