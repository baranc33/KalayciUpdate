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
    public class SpoolRepository : EfEntityRepositoryBase<Spool>, ISpoolRepository
    {

        private KalayciContext _context;
       

        public SpoolRepository(KalayciContext context) : base(context)
        {
            _context=context;

        }

        public async Task<(bool, ICollection<Spool>,string)> AddRangeSpoolistAsync(ICollection<Spool> spools)
        {

            try
            {
                await _context.Spool.AddRangeAsync(spools);
                return (true, spools,"");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                string message =$"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, spools, message);
            }
        }
    }
}
