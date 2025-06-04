using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface ISendingRepository : IEntityRepository<Sending>
    {
        Task<(bool, string)> AutomaticAddRange(ICollection<Sending> sendings);

    }
}
