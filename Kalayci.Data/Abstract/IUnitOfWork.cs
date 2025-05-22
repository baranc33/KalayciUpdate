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
        //IArticleRepository Articles { get; }

        ICircuitDeliveryRepository CircuitDelivery { get; }
        ICircuitListRepository CircuitList { get; }
        IRoleRepository Role { get; }
        IProjectRepository Project { get; }
        ISendingRepository Sending { get; }
        IShipYardRepository ShipYard { get; }
        IShipyardAssemblyRepository ShipyardAssembly { get; }
        ISpoolRepository Spool { get; }
        IUserRepository User { get; }
        IWeldingRepository Welding { get; }
        IWorkPlaceRepository WorkPlace { get; }

        Task<int> SaveAsync();
    }

}
