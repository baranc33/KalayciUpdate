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
    public class ProjectRepository : EfEntityRepositoryBase<Project>, IProjectRepository
    {

        private KalayciContext _context;
        public ProjectRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Project>> projectsWithUser()
        {
            return await _context.Project.Include(x => x.User).ToListAsync();
        }

        public async Task<ICollection<Project>> projectsWithUserAndSpoolList()
        { 
            return await _context.Project.Include(x => x.User)
                .Include(x => x.User)
                .Include(s => s.spoolLists)
                .ThenInclude(s => s.CircuitList)
                .ToListAsync();
        }
    }
}
