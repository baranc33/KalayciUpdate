using Kalayci.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Shared.Data.Abstract
{
    // bu sayfa daha sonra Kodlanıp GenericHale Getirilecektir.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        Task<IEnumerable<T>> GetAllAsyncAmount(int Skip, int Take, Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAllAsyncAmountInclude(int Skip, int Take, Expression<Func<T, bool>> filter = null , 
            params Expression<Func<T, object>>[] includeProperties);
 
        Task<T> AddAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);



        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);
     


        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
       

    }
}
