using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete;
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
        private readonly ISpoolRepository _spoolRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IEntityRepository<Project> repository, IUnitOfWork unitOfWork,
            IProjectRepository projectRepository, ISpoolRepository spoolRepository) : base(unitOfWork, repository)
        {
            _unitOfWork= unitOfWork;
            _spoolRepository = spoolRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ICollection<Project>> projectsWithUser()
        {
            return await _projectRepository.projectsWithUser();
        }

        public async Task<ICollection<Project>> projectsWithUserAndSpoolList()
        {
            return await _projectRepository.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<string> RemoveProject(string ProjectId)
        {
            ICollection<Spool> spools = await _spoolRepository.GetAllAsync(x => x.ProjectId== Convert.ToInt32(ProjectId));// 1milyon


            if (spools.Count>0)
            {
                return $"Projeye Bağlı {spools.Count()} adet Spool Vardır önce spoolların silmelisiniz.";
            }
            Project project = await _projectRepository.GetAsync(x => x.Id == Convert.ToInt32(ProjectId));
            await _projectRepository.DeleteAsync(project);
          await  _unitOfWork.SaveAsync();
            return $"  {project.ProjectName} Projesi Başarıyla Silindi.";

        }
    }
}
