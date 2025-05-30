using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete.Entities
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IEntityRepository<Project> repository, IUnitOfWork unitOfWork,IProjectRepository projectRepository) : base(unitOfWork, repository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ICollection<Project>> projectsWithUser()
        {
          return await _projectRepository.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<ICollection<Project>> projectsWithUserAndSpoolList()
        {
           return await _projectRepository.GetAllAsync(x => x.IsDeleted == false);
        }
    }
}
