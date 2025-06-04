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
    public class WeldingRepository : EfEntityRepositoryBase<Welding>, IWeldingRepository
    {
        private KalayciContext _context;
        public WeldingRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(bool, string)> AutomaticAddRange(ICollection<Welding>  weldings)
        {

            try
            {
                await _context.Welding.AddRangeAsync(weldings);
                return (true,"");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                string message= $"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, message);
            }
        }
    }
}
