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
    public class PointRepository : EfEntityRepositoryBase<Point>, IPointRepository
    {
        private KalayciContext _context;

        public PointRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }
    }
}
