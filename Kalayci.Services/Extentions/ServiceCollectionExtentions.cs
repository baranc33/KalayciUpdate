using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Data.Concrete.EntityFrameWork.Repositories;
using Kalayci.Services.Abstract;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete;
using Kalayci.Services.Concrete.Entities;
using Kalayci.Shared.Data.Abstract;
using Kalayci.Shared.Data.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<KalayciContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            serviceCollection.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));







            serviceCollection.AddScoped<IEmployeeExitRepository, EmployeeExitRepository>();
            serviceCollection.AddScoped<IEmployeeExitService, EmployeeExitService>();


            serviceCollection.AddScoped<IBranchRepository, BranchRepository>();
            serviceCollection.AddScoped<IBranchService, BranchService>();


            serviceCollection.AddScoped<ICircuitDeliveryRepository, CircuitDeliveryRepository>();
            serviceCollection.AddScoped<ICircuitDeliveryService, CircuitDeliveryService>();

            serviceCollection.AddScoped<ICircuitListRepository, CircuitListRepository>();
            serviceCollection.AddScoped<ICircuitListService, CircuitListService>();
            
            serviceCollection.AddScoped<IKalayciRoleRepository, KalayciRoleRepository>();
            serviceCollection.AddScoped<IKalayciRoleService, KalayciRoleService>();
            
            serviceCollection.AddScoped<IKalayciUserRepository, KalayciUserRepository>();
            serviceCollection.AddScoped<IKalayciUserService, KalayciUserService>();
            
            serviceCollection.AddScoped<IPersonelRepository, PersonelRepository>();
            serviceCollection.AddScoped<IPersonelService, PersonelService>();
            
            serviceCollection.AddScoped<IPointRepository, PointRepository>();
            serviceCollection.AddScoped<IPointService, PointService>();
            
            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IProjectService, ProjectService>();
            
            serviceCollection.AddScoped<ISendingRepository, SendingRepository>();
            serviceCollection.AddScoped<ISendingService, SendingService>();
            
            serviceCollection.AddScoped<IShipYardAssemblyRepository, ShipYardAssemblyRepository>();
            serviceCollection.AddScoped<IShipYardAssemblyService, ShipYardAssemblyService>();
            
            serviceCollection.AddScoped<IShipYardRepository, ShipYardRepository>();
            serviceCollection.AddScoped<IShipYardService, ShipYardService>();
            
            serviceCollection.AddScoped<ISpoolRepository, SpoolRepository>();
            serviceCollection.AddScoped<ISpoolService, SpoolService>();
            
            serviceCollection.AddScoped<IWeldingRepository, WeldingRepository>();
            serviceCollection.AddScoped<IWeldingService, WeldingService>();
            
            serviceCollection.AddScoped<IWorkPlaceRepository, WorkPlaceRepository>();
            serviceCollection.AddScoped<IWorkPlaceService, WorkPlaceService>();





            return serviceCollection;
        }
    }
}
