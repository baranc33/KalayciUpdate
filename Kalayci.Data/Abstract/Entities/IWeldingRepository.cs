using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface IWeldingRepository : IEntityRepository<Welding>
    {
        Task<(bool, string)> AutomaticAddRange(ICollection<Welding>  weldings);

    }
}
