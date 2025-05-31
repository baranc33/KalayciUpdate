using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class KalayciUserRepository : EfEntityRepositoryBase<KalayciUser>, IKalayciUserRepository
    {
        private KalayciContext _context;
        public KalayciUserRepository(KalayciContext context) : base(context)
        {
            _context=context;
        }

      

        public async Task<KalayciUser> IncludePersonelThenIncludeBranch(string UserID)
        {

            return await _context.Users.Where(x => x.Id==UserID)
                    .Include(x => x.personel)
                .ThenInclude(x => x.branch).SingleOrDefaultAsync();
        }

        public async Task<ICollection<KalayciUser>> GetAllIncludePersonelThenIncludeBranch()
        {
            return await _context.Users.Where(x => x.IsDeleted==false)
                  .Include(x => x.personel)
              .ThenInclude(x => x.branch).
              ToListAsync();
        }
    }
}
