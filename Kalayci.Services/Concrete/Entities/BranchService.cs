using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Mappings;
using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete.Entities
{
    public class BranchService : GenericService<Branch>, IBranchService
    {

        private IBranchRepository _branchRepository;

        public BranchService(IUnitOfWork unitOfWork, IEntityRepository<Branch> repository) : base(unitOfWork, repository)
        {
        }

        public BranchService(IEntityRepository<Branch> repository, IUnitOfWork unitOfWork, IBranchRepository branchRepository) : base(unitOfWork, repository)
        {
            _branchRepository  = branchRepository;
        }

        //public async Task<BraanchListWieModel> GetAllBranchAsync(bool AllList, bool IsDelete)
        //{
            
    
        //    throw new NotImplementedException();
        //}

        public async Task<ICollection<Branch>> GetBranchesAsyncOrderByName()
        {

            return await _branchRepository.GetBranchesAsyncOrderByName();
        }

        public Task<ICollection<Branch>> GetBranchesAsyncOrderByName(bool Valu)
        {
            throw new NotImplementedException();
        }
    }
}
