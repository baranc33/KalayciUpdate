using Kalayci.Shared.Entities.Abstract;
using Kalayci.Shared.Utilitis.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract
{
    public interface IGenericService<T> where T : class,   IEntity,new()
    {
        Task<T> AddAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
         params Expression<Func<T, object>>[] includeProperties);



        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
