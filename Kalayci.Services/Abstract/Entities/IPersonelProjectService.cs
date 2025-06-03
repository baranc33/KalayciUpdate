using Kalayci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{
    public interface IPersonelProjectService : IGenericService<PersonelProject>
    {
        Task<PersonelProject> ActivePersonelProjectInculude(int personelId);
        Task<bool> AutomaticPersonFiilProject();
    }
}
