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
    public class ProjectRepository : EfEntityRepositoryBase<Project>, IProjectRepository
    {

        public ProjectRepository(DbContext context) : base(context)
        {
        }
    }
}
