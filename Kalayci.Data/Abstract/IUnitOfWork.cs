using Kalayci.Data.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract
{

    public interface IUnitOfWork : IAsyncDisposable
    {
        IBranchRepository BranchRepository { get; }
        ICircuitDeliveryRepository CircuitDelivery { get; }
        ICircuitListRepository CircuitList { get; }
        IKalayciRoleRepository Role { get; }
        IKalayciUserRepository User{ get; }
        IProjectRepository Project { get; }
        IPersonelRepository Personel { get; }
        IPointRepository Point { get; }
        ISendingRepository Sending { get; }
        IShipYardRepository ShipYard { get; }
        IShipYardAssemblyRepository ShipyardAssembly { get; }
        ISpoolRepository Spool { get; }
     
        IWeldingRepository Welding { get; }
        IWorkPlaceRepository WorkPlace { get; }

        Task<int> SaveAsync();
    }

}
