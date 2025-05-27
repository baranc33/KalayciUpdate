using Kalayci.Data.Abstract;
using Kalayci.Services.Abstract;
using Kalayci.Shared.Data.Abstract;
using Kalayci.Shared.Entities.Abstract;
using Kalayci.Shared.Enums;
using Kalayci.Shared.Utilitis.Result.Abstract;
using Kalayci.Shared.Utilitis.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete
{

    // Daha Sonra Bu Sayfada Kodlanıp generic hale getirilecektir.
    public class GenericService<T> : IGenericService<T> where T : class, IEntity, new()
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<T> _repository;
        public GenericService(IUnitOfWork unitOfWork, IEntityRepository<T> repository)
        {
            _repository=repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T Entity)
        {
            await _repository.AddAsync(Entity);
            await _unitOfWork.SaveAsync();
            return Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            await _repository.DeleteAsync(Entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAllAsync(predicate, includeProperties);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return await _repository.GetAsync(predicate, includeProperties);
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            await _repository.UpdateAsync(Entity);
            await _unitOfWork.SaveAsync();
            return Entity;
        }
    }
}
