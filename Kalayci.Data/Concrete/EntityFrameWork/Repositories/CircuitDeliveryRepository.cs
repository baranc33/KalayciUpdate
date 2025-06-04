using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class CircuitDeliveryRepository : EfEntityRepositoryBase<CircuitDelivery>, ICircuitDeliveryRepository
    {
        private KalayciContext _context;
        public CircuitDeliveryRepository(KalayciContext context) : base(context)
        {
            _context = context;
        }



        public async Task<(bool,string)> AutomaticAddRange(ICollection<CircuitDelivery>  circuitDeliveries)
        {

            try
            {
                await _context.CircuitDelivery.AddRangeAsync(circuitDeliveries);
                return (true,"");
            }
            catch (Exception ex)
            {
                string message = $"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, message);
            }
        }
    }
}

