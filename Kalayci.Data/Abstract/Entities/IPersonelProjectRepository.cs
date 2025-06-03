using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface IPersonelProjectRepository : IEntityRepository<PersonelProject>
    {
        Task<PersonelProject> ActivePersonelProjectInculude(int personelId);
        Task<bool> AutomaticPersonFiilProject();

    }
}
