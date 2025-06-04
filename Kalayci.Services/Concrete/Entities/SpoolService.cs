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
    public class SpoolService : GenericService<Spool>, ISpoolService
    {
        private IPersonelRepository _personelRepository;
        private readonly IKalayciUserService _kalayciUserService;
        private readonly IPersonelProjectRepository _personelProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPointService _pointService;
        private readonly ISpoolRepository _spoolRepository;

        private readonly ICircuitDeliveryRepository _circuitDeliveryRepository;
        private readonly ISendingRepository _sendingRepository;
        private readonly IShipYardAssemblyRepository _shipYardAssemblyRepository;
        private readonly IWeldingRepository _weldingRepository;
        private readonly IWorkPlaceRepository _workPlaceRepository;
        public SpoolService(IEntityRepository<Spool> repository, IUnitOfWork unitOfWork,
            IPersonelRepository personelRepository,
            IKalayciUserService kalayciUserService,
            IPersonelProjectRepository personelProjectRepository,
            IPointService pointService,
            ISpoolRepository spoolRepository,
            ICircuitDeliveryRepository circuitDeliveryRepository,
            ISendingRepository sendingRepository,
            IShipYardAssemblyRepository shipYardAssemblyRepository, 
            IWeldingRepository weldingRepository,
            IWorkPlaceRepository workPlaceRepository
            ) : base(unitOfWork, repository)
        {
            _circuitDeliveryRepository = circuitDeliveryRepository;
            _sendingRepository = sendingRepository;
            _shipYardAssemblyRepository = shipYardAssemblyRepository;
            _weldingRepository = weldingRepository;
            _workPlaceRepository = workPlaceRepository;
            _pointService= pointService;
            _personelProjectRepository =personelProjectRepository;
            _kalayciUserService = kalayciUserService;
            _unitOfWork = unitOfWork;
            _personelRepository=personelRepository;
            _spoolRepository = spoolRepository;
        }


        public async Task<(bool,string)> AddRangeSpoolistAsyncAutomatikExcelList(ICollection<Spool> spools)
        {
            (bool, ICollection<Spool>,string) result = await _spoolRepository.AddRangeSpoolistAsync(spools);
            if (result.Item1)
            {
                string ErrorMessage = "";

                await _unitOfWork.SaveAsync();

                // spoollar eklendiyse ilk Tablosu Olan Atloye Tablosunuda oluşturalım

                ICollection<WorkPlace> workPlaces = new List<WorkPlace>();
                ICollection<Welding> weldings = new List<Welding>();
                ICollection<CircuitDelivery> circuitDeliveries = new List<CircuitDelivery>();
                ICollection<Sending> sendings = new List<Sending>();
                ICollection<ShipyardAssembly> shipyardAssemblys = new List<ShipyardAssembly>();
                // diğer tabloları oluşturcaz.
                foreach (var item in result.Item2)
                {
                    WorkPlace workPlace = new WorkPlace()
                    {
                        SpoolCreatedByName="Sistem Otomatik Giriş",
                        spoolId=item.Id,
                        CreatedByName=item.CreatedByName,
                        ModifiedByName=item.ModifiedByName,
                    };
                    workPlaces.Add(workPlace);

                    Welding welding = new Welding()
                    {
                        Status=0,
                        // bekliyor
                        SpoolWeldingType=0,
                        spoolId=item.Id,
                        CreatedByName=item.CreatedByName,
                        ModifiedByName=item.ModifiedByName,
                    };
                    weldings.Add(welding);

                    CircuitDelivery circuitDelivery = new CircuitDelivery()
                    {
                        spoolId=item.Id,
                        CreatedByName=item.CreatedByName,
                        ModifiedByName=item.ModifiedByName,
                        QualityControl=false,
                        Grinding =false,
                        PressureTest =false,
                        Dimensioning =false,
                        WeldingTest =false
                    };
                    circuitDeliveries.Add(circuitDelivery);

                    Sending sending = new Sending()
                    {
                        spoolId=item.Id,
                        CreatedByName=item.CreatedByName,
                        ModifiedByName=item.ModifiedByName,
                        Place=0,
                        Status=0

                    };
                    sendings.Add(sending);

                    ShipyardAssembly shipyardAssembly = new ShipyardAssembly()
                    {
                        spoolId=item.Id,
                        CreatedByName=item.CreatedByName,
                        ModifiedByName=item.ModifiedByName,
                        Status=0,
                        SpoolAssemblyByName="Sistem Otomatik Giriş"
                    };
                    shipyardAssemblys.Add(shipyardAssembly);


                }


                //await _co.WorkPlaceRepository.AddRangeAsync(workPlaces);
                (bool, string) workPlacesresult =  await _workPlaceRepository.AutomaticAddRange(workPlaces);
                if (workPlacesresult.Item1) await _unitOfWork.SaveAsync();
                else ErrorMessage += $"Atölye Tablosuna Veri Eklerken Hata Oluştu . {workPlacesresult.Item2}";


                (bool, string) Weldingresult = await _weldingRepository.AutomaticAddRange(weldings);
                if (Weldingresult.Item1) await _unitOfWork.SaveAsync();
                else ErrorMessage += $"Kaynak Tablosuna Veri Eklerken Hata Oluştu . {Weldingresult.Item2}";


                (bool, string) circuitDeliveriesresult =  await _circuitDeliveryRepository.AutomaticAddRange(circuitDeliveries);
                if (circuitDeliveriesresult.Item1) await _unitOfWork.SaveAsync();
                else ErrorMessage += $"Devre Teslim Tablosuna Veri Eklerken Hata Oluştu . {circuitDeliveriesresult.Item2}";


                (bool, string) sendingsresult =  await _sendingRepository.AutomaticAddRange(sendings);
                if (sendingsresult.Item1) await _unitOfWork.SaveAsync();
                else ErrorMessage += $"Sevk Tablosuna Veri Eklerken Hata Oluştu . {sendingsresult.Item2}";


                (bool, string) shipyardAssemblysresult =  await _shipYardAssemblyRepository.AutomaticAddRange(shipyardAssemblys);
                if (shipyardAssemblysresult.Item1) await _unitOfWork.SaveAsync();
                else ErrorMessage += $"Tersane Montaj Tablosuna Veri Eklerken Hata Oluştu . {shipyardAssemblysresult.Item2}";



                if (workPlacesresult.Item1 && Weldingresult.Item1 && circuitDeliveriesresult.Item1 && sendingsresult.Item1 && shipyardAssemblysresult.Item1)
                {
                    // tüm tablolar eklendi ise true döner
                    return (true, $"{workPlaces.Count()*6} Adet Veri Ekleme işlemi Başarıyla Tamamlandı.") ;
                }
              

                return (false,ErrorMessage);

            }
            else
            {
                return (false, result.Item3);
            }

        }
    }
}
