using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface ISpoolRepository : IEntityRepository<Spool>
    {
        
        Task<(bool, ICollection<Spool>,string)> AddRangeSpoolistAsync(ICollection<Spool> spools);
        Task<ICollection<PersonelProject>> GetProjectAllPersonelAndAllSpool(int projectId);

        Task<ProjectPercentageCalculate> ProjectPercentageCalculate(int projectId);

    }
}
