using Kalayci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{
    public interface IProjectService : IGenericService<Project>
    {
        Task<ICollection<Project>> projectsWithUser();
        Task<ICollection<Project>> projectsWithUserAndSpoolList();

        Task<string> RemoveProject(string ProjectId);
    }
}
