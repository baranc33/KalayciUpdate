﻿using Kalayci.Data.Abstract.Entities;
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
    public class WorkPlaceRepository : EfEntityRepositoryBase<WorkPlace>, IWorkPlaceRepository
    {
        private KalayciContext _context;
        public WorkPlaceRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(bool, string)> AutomaticAddRange(ICollection<WorkPlace> workPlaces)
        {

            try
            {
                await _context.WorkPlace.AddRangeAsync(workPlaces);
                return (true,"");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                string message = $"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, message);
            }
        }
    }
}
