using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Shared.Data.Abstract;
using Kalayci.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Kalayci.Shared.Data.Concrete
{

    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
where TEntity : class, IEntity, new()
    {
        private readonly KalayciContext _context;
        public EfEntityRepositoryBase(KalayciContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyncAmount(int Skip, int Take,Expression<Func<TEntity, bool>> filter = null)
        {

            IQueryable<TEntity> Data = _context.Set<TEntity>();
            if (filter != null)
            {
                Data = Data.Where(filter);
            }
          
            var newData = await Data.Skip(Skip).Take(Take).ToListAsync();
            return newData;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsyncAmountInclude(int Skip, int Take, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> Data = _context.Set<TEntity>();
            if (filter != null)
            {
                Data = Data.Where(filter);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    Data = Data.Include(includeProperty);
                }
            }
            var newData = await Data.Skip(Skip).Take(Take).ToListAsync();
            return newData;
        }


        public async Task<TEntity> AddAsync(TEntity Entity)
        {
            await _context.Set<TEntity>().AddAsync(Entity);
            return Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity Entity)
        {
            await Task.Run(() =>
            {
                _context.Set<TEntity>().Update(Entity);
            });
            return Entity;
        }

        public async Task DeleteAsync(TEntity Entity)
        {
            await Task.Run(() =>
                     {
                         _context.Set<TEntity>().Remove(Entity);
                     });
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();


            if (includeProperties != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeproperty in includeProperties)
                {
                    query = query.Include(includeproperty);

                }
            }

            return await query.SingleOrDefaultAsync();

        }


        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            //<TEntity, int,bool>
            //return await query.SkipWhile(). SkipWhile(12,predicate);

            return await query.ToListAsync();
        }





        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

    }
}
