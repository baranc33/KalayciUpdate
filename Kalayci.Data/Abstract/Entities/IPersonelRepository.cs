using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface IPersonelRepository : IEntityRepository<Personel>
    {
      Task<ICollection<Personel>> GettAllIncludeBranch();
      Task<ICollection<Personel>> GettBranchPersonels(int BranchId);
    }
}
