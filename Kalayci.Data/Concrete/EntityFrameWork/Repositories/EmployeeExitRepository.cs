using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class EmployeeExitRepository : EfEntityRepositoryBase<EmployeeExit>, IEmployeeExitRepository
    {

        public EmployeeExitRepository(KalayciContext context) : base(context)
        {
        }
    }
}
