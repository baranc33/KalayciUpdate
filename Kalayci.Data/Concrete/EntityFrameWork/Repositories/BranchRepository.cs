using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class BranchRepository : EfEntityRepositoryBase<Branch>, IBranchRepository
    {
        private KalayciContext _context;
        public BranchRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }


      

        public async Task<ICollection<Branch>> GetBranchesAsyncOrderByName()
        {
           return await _context.Branches.Where(x => x.IsDeleted == false)
                .OrderBy(x => x.BranchName)
                .ToListAsync();
        }
    }
}

