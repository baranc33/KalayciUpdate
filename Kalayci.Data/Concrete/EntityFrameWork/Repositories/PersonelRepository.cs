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
    public class PersonelRepository : EfEntityRepositoryBase<Personel>, IPersonelRepository
    {
        private  KalayciContext _context;
        public PersonelRepository(KalayciContext context ) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Personel>> GettAllIncludeBranch()
        {
            ICollection<Personel> personels = await _context.Personel.Where(x=>x.IsDeleted==false).Include(x=>x.branch).OrderBy(x=>x.Name).ToListAsync();


                return personels;
        }

        public async Task<ICollection<Personel>> GettBranchPersonels(int BranchId)
        {
          return  await _context.Personel.Where(x=>x.IsDeleted==false&& x.branchId==BranchId)
                .Include(u=>u.ManagerUser)
                .ThenInclude(u => u.personel)
                .Include(x => x.branch).OrderBy(x => x.Name).ToListAsync();
        }
    }
}
