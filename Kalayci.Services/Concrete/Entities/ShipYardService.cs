using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete.Entities
{
    public class ShipYardService : GenericService<ShipYard>, IShipYardService
    {
        private readonly IShipYardRepository _shipYardRepository;
        public ShipYardService(IEntityRepository<ShipYard> repository, IUnitOfWork unitOfWork, IShipYardRepository shipYardRepository) : base(unitOfWork, repository)
        {
            _shipYardRepository= shipYardRepository;
        }


        public async Task<ShipYard> GetAllShipYardInculudeProjectsThenInculedeUser(int shipYardId)
        {
        return await _shipYardRepository.GetAllShipYardInculudeProjectsThenInculedeUser(shipYardId);
        }
    }
}
