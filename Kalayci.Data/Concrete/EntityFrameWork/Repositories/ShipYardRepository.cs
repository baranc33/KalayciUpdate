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
    public class ShipYardRepository : EfEntityRepositoryBase<ShipYard>, IShipYardRepository
    {
        private KalayciContext _context;
        public ShipYardRepository(KalayciContext context) : base(context)
        {
            _context=context;
        }

        public async Task<ShipYard> GetAllShipYardInculudeProjectsThenInculedeUser(int shipYardId)
        {

         return  await _context.ShipYard.Where(x=>x.Id==shipYardId).Include(p=>p.Projects).ThenInclude(p => p.User)
                .ThenInclude(p=>p.personel)
                .OrderByDescending(n=>n.Id).SingleOrDefaultAsync();
        }
    }
}
