using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICircuitDeliveryRepository CircuitDelivery => throw new NotImplementedException();

        public ICircuitListRepository CircuitList => throw new NotImplementedException();

        //public IRoleRepository Role => throw new NotImplementedException();

        public IProjectRepository Project => throw new NotImplementedException();

        public ISendingRepository Sending => throw new NotImplementedException();

        public IShipYardRepository ShipYard => throw new NotImplementedException();

        public IShipyardAssemblyRepository ShipyardAssembly => throw new NotImplementedException();

        public ISpoolRepository Spool => throw new NotImplementedException();

        //public IUserRepository User => throw new NotImplementedException();

        public IWeldingRepository Welding => throw new NotImplementedException();

        public IWorkPlaceRepository WorkPlace => throw new NotImplementedException();

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
