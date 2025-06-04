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
    public class ShipYardAssemblyRepository : EfEntityRepositoryBase<ShipyardAssembly>, IShipYardAssemblyRepository
    {
        private KalayciContext _context;
        public ShipYardAssemblyRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }


        public async Task<(bool, string)> AutomaticAddRange(ICollection<ShipyardAssembly>  shipyardAssemblies)
        {

            try
            {
                await _context.ShipyardAssembly.AddRangeAsync(shipyardAssemblies);
                return (true,"");
            }
            catch (Exception ex)
            {
                string message = $"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, message);
            }
        }
    }
}
