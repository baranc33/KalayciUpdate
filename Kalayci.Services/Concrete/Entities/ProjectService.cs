using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete;
using Kalayci.Data.Concrete.EntityFrameWork.Repositories;
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
        private readonly IPersonelProjectRepository _personelProjectRepository;
        private readonly ISpoolRepository _spoolRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IEntityRepository<Project> repository, IUnitOfWork unitOfWork,
            IProjectRepository projectRepository, ISpoolRepository spoolRepository,
            IPersonelProjectRepository personelProjectRepository) : base(unitOfWork, repository)
        {
            _personelProjectRepository=personelProjectRepository;
            _unitOfWork = unitOfWork;
            _spoolRepository = spoolRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ICollection<Project>> projectsWithUser(int ShipYardID)
        {
            return await _projectRepository.projectsWithUser(ShipYardID);
        }

        public async Task<ICollection<Project>> projectsWithUserAndSpoolList()
        {
            return await _projectRepository.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<string> RemoveProject(string ProjectId)
        {
            ICollection<Spool> spools = await _spoolRepository.GetAllAsync(x => x.ProjectId== Convert.ToInt32(ProjectId));// 
            ICollection<PersonelProject> personelProjects = await _personelProjectRepository.GetAllAsync(x => x.ProjectId== Convert.ToInt32(ProjectId));// 


            if (spools.Count>0)
            {
                return $"Projeye Bağlı {spools.Count()} adet Spool Vardır önce spoolların silmelisiniz.";
            }

            if (personelProjects.Count>0)
            {
                return $"Projeye Bağlı {personelProjects.Count()} adet Personel Vardır önce Personelleri Atamalısınız.";
            }


            Project project = await _projectRepository.GetAsync(x => x.Id == Convert.ToInt32(ProjectId));
            await _projectRepository.DeleteAsync(project);
          await  _unitOfWork.SaveAsync();
            return $"  {project.ProjectName} Projesi Başarıyla Silindi.";

        }
    }
}
