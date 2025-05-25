using Kalayci.Data.Abstract.Entities;
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
    public class WeldingRepository : EfEntityRepositoryBase<Welding>, IWeldingRepository
    {

        public WeldingRepository(DbContext context) : base(context)
        {
        }
    }
}
