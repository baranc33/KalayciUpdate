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
        public UnitOfWork(KalayciContext context)
        {
            _context=context;
        }

        private EmployeeExitRepository _employeeExitRepository;
        private BranchRepository _branchRepository;
        private CircuitDeliveryRepository _circuitDeliveryRepository;
        private CircuitListRepository _circuitListRepository;
        private KalayciRoleRepository _roleRepository;
        private KalayciUserRepository _kalayciUserRepository;
        private PersonelRepository _personelRepository;
        private PointRepository _pointRepository;
        private ProjectRepository _projectRepository;
        private SendingRepository _sendingRepository;
        private ShipYardAssemblyRepository _shipYardAssemblyRepository;
        private ShipYardRepository _shipYardRepository;
        private SpoolRepository _spoolRepository;
        private WeldingRepository _weldingRepository;
        private WorkPlaceRepository _workPlaceRepository;
        private PersonelProjectRepository _personelProjectRepository;



        public IBranchRepository BranchRepository =>
            _branchRepository ?? new BranchRepository(_context);
        public ICircuitDeliveryRepository CircuitDelivery =>
            _circuitDeliveryRepository ?? new CircuitDeliveryRepository(_context);

        public ICircuitListRepository CircuitList =>
            _circuitListRepository ?? new CircuitListRepository(_context);

        public IProjectRepository Project =>
            _projectRepository ?? new ProjectRepository(_context);

        public IPersonelRepository Personel =>
            _personelRepository ?? new PersonelRepository(_context);

        public IPointRepository Point =>
            _pointRepository ?? new PointRepository(_context);

        public ISendingRepository Sending =>
            _sendingRepository ?? new SendingRepository(_context);

        public IShipYardRepository ShipYard =>
            _shipYardRepository ?? new ShipYardRepository(_context);

        public IShipYardAssemblyRepository ShipyardAssembly =>
            _shipYardAssemblyRepository ?? new ShipYardAssemblyRepository(_context);

        public ISpoolRepository Spool =>
            _spoolRepository ?? new SpoolRepository(_context);

        public IWeldingRepository Welding =>
            _weldingRepository ?? new WeldingRepository(_context);

        public IWorkPlaceRepository WorkPlace =>
            _workPlaceRepository ?? new WorkPlaceRepository(_context);

        public IKalayciRoleRepository Role =>
            _roleRepository ?? new KalayciRoleRepository(_context);

        public IKalayciUserRepository User =>
            _kalayciUserRepository ?? new KalayciUserRepository(_context);

        public IEmployeeExitRepository EmployeeExitRepository =>
             _employeeExitRepository ?? new EmployeeExitRepository(_context);

        public IPersonelProjectRepository PersonelProjectRepository =>
              _personelProjectRepository ?? new PersonelProjectRepository(_context);

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
