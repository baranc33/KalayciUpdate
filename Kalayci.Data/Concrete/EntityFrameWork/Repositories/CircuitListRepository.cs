using Kalayci.Data.Abstract.Entities;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class CircuitListRepository : EfEntityRepositoryBase<CircuitList>, ICircuitListRepository
    {

        public CircuitListRepository(DbContext context) : base(context)
        {
        }
    }
}
