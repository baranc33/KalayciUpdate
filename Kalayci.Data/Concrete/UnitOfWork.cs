using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Data.Concrete.EntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly KalayciContext _context;
        private CircuitDeliveryRepository _circuitDeliveryRepository;




        public ICircuitDeliveryRepository CircuitDelivery => 
            _circuitDeliveryRepository ?? new CircuitDeliveryRepository(_context);

        public ICircuitListRepository CircuitList => throw new NotImplementedException();

        public IProjectRepository Project => throw new NotImplementedException();

        public IPersonelRepository Personel => throw new NotImplementedException();

        public IPointRepository Point => throw new NotImplementedException();

        public ISendingRepository Sending => throw new NotImplementedException();

        public IShipYardRepository ShipYard => throw new NotImplementedException();

        public IShipYardAssemblyRepository ShipyardAssembly => throw new NotImplementedException();

        public ISpoolRepository Spool => throw new NotImplementedException();

        public IWeldingRepository Welding => throw new NotImplementedException();

        public IWorkPlaceRepository WorkPlace => throw new NotImplementedException();




        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
