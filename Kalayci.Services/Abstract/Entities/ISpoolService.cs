using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{
    public interface ISpoolService : IGenericService<Spool>
    {
        Task<IEnumerable<Spool>> GetAllAsyncAmount(int value, int valu2, Expression<Func<Spool, bool>> filter = null);

        Task<(bool, string)> AddRangeSpoolistAsyncAutomatikExcelList(ICollection<Spool> spools);
        Task<ICollection<PersonelProject>> GetProjectAllPersonelAndAllSpoolsAsync(int projectId);
        Task<ProjectPercentageCalculate> ProjectPercentageCalculate(int projectId);
    }
}
