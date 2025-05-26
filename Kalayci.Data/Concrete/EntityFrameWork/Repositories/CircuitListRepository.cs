using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class CircuitListRepository : EfEntityRepositoryBase<CircuitList>, ICircuitListRepository
    {

        public CircuitListRepository(KalayciContext context) : base(context)
        {
        }
    }
}
