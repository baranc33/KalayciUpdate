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
    public class PersonelService : GenericService<Personel>, IPersonelService
    {
        private IPersonelRepository _personelRepository;
        private readonly IKalayciUserService _kalayciUserService;
        private readonly IPersonelProjectRepository _personelProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPointService _pointService;
        public PersonelService(IEntityRepository<Personel> repository, IUnitOfWork unitOfWork,
            IPersonelRepository personelRepository,
            IKalayciUserService kalayciUserService,
            IPersonelProjectRepository personelProjectRepository,
            IPointService pointService
            ) : base(unitOfWork, repository)
        {
            _pointService= pointService;
            _personelProjectRepository =personelProjectRepository;
            _kalayciUserService = kalayciUserService;
            _unitOfWork = unitOfWork;
            _personelRepository=personelRepository;
        }

        public async Task<ICollection<Personel>> GettAllIncludeBranch()
        {
            return await _personelRepository.GettAllIncludeBranch();
        }

        public async Task<ICollection<Personel>> GettBranchPersonels(int BranchId)
        {
            return await _personelRepository.GettBranchPersonels(BranchId);
        }

        public async Task<(Personel, bool,string)> UpdatePersonelWithProjectsAsync(Personel personel, int projectID,bool checkChangeManagerUserId)
        {

            // personelin projesi değişmişmi ? 
            Personel OldPersonel = await _personelRepository.GetAsync(x => x.Id==personel.Id, p => p.PersonelProjects);
            var OldPersonelActiveProjectId = await _personelProjectRepository.GetAsync(x => x.PersonelId==OldPersonel.Id && x.IsActiveWork== true);

            //1. adım Personeli güncellemeden  önce aktif projesi varmı kontrol ediyoruz.
            PersonelProject MypersonelProject = await _personelProjectRepository.GetAsync(x => x.PersonelId==personel.Id && x.IsActiveWork== true);
            // personelin Daha önce Bağlı Bulunduğu Proje yoksa
            if (MypersonelProject==null)
            {// personele daha önce proje eklenmemişse
                await AddPersonelProject(personel, projectID);
            }
            // // proje veya yetkili değiştirmiyor sa güncellemeye devam
     
            else if(OldPersonelActiveProjectId.ProjectId != projectID || checkChangeManagerUserId)
            // personelin projesi yada yönetici değiştiyse
            {
                // projede çalıştığı süre puanlar Girilmişmi kontrolü yapıyoruz

                DateTime StartWorkTime = personel.WorkStartDate;
                int MountDay = StartWorkTime.Day-1;
                StartWorkTime= StartWorkTime.AddDays(-MountDay);

                DateTime ThisDate = DateTime.Now;
                int ThisMountDay = ThisDate.Day-1;
                ThisDate= ThisDate.AddDays(-ThisMountDay);


                string Message = null;
                int countMessage = 0;


                while (StartWorkTime<ThisDate.AddMonths(-1))
                {
                  ICollection<Point> point = await _pointService.GetAllAsync(x => x.PersonelId==personel.Id && x.GiveDateStart==StartWorkTime);


                    if (point.Count()==0)
                    {
                        Message+=$"{StartWorkTime.Year}  {GetMountNameTurkish(StartWorkTime.Month)} ,"+" "+" ";
                        countMessage++;
                    }
                    StartWorkTime= StartWorkTime.AddMonths(1);

                }
                if (Message!=null)
                {
                    if (countMessage>1)
                    {
                        Message+=" Aylarının Puanları Girilmemiştir. Personel Atama işleminden önce Puanları Giriniz Girme Yetkiniz Yoksa Bilgi işleme Başvurunuz";
                        return (personel, false, Message);

                    }
                    else
                    {
                        Message+="Ayının Puanı Girilmemiştir. Personel Atama işleminden önce Puanları Giriniz Girme Yetkiniz Yoksa Bilgi işleme Başvurunuz";
                        return (personel, false, Message);
                    }
                }

                // önceki projesini pasife alıyoruz daha sonra yeni projeye atıyoruz.

                PersonelProject personelProject = await _personelProjectRepository.GetAsync(x => x.PersonelId==personel.Id && x.IsActiveWork==true);
                // güncelleme yaparkenproje değişmiş diye kontrol ediyoruz
                if (personelProject.ProjectId!=projectID)
                {
                    // personelin aktif projesi var ise ve değişmiş ise
                    personelProject.IsActiveWork=false;
                    personelProject.FinishDate=DateTime.Now;
                    personelProject.ModifiedByName=personel.ModifiedByName;
                    personelProject.ModifiedDate=DateTime.Now;
                    personelProject.IsActiveWork=false;
                    await _personelProjectRepository.UpdateAsync(personelProject);
                    // yeni proje çalışmasını ekliyoruz
                    await AddPersonelProject(personel, projectID);
                }


            }

       










            await _personelRepository.UpdateAsync(personel);
            await _unitOfWork.SaveAsync();

            // personelin bağlı bulunduğu projeyi oluşturduk
            // şimdi personeli güncelliyoruz.

            return (personel, true,"");
        }


        private async Task AddPersonelProject(Personel request, int projectID)
        {

            var user = await _kalayciUserService.GetAsync(x => x.Id==request.ManagerUserId, p => p.personel);
            PersonelProject newPersonelProject = new PersonelProject()
            {
                BranchId=request.branchId,
                CreatedByName=request.CreatedByName,
                ModifiedByName=request.CreatedByName,
                CreatedDate=DateTime.Now,
                ModifiedDate=DateTime.Now,
                IsActiveWork=true,
                PersonelId=request.Id,
                ProjectId=projectID,
                StartDate=DateTime.Now,
                ManagerName=user.personel.Name + " " + user.personel.LastName,
            };
            await _personelProjectRepository.AddAsync(newPersonelProject);
        }



        public string GetMountNameTurkish(int MountNumber)
        {
            switch (MountNumber)
            {
                case 1:
                    return "Ocak";
                case 2:
                    return "Şubat";
                case 3:
                    return "Mart";
                case 4:
                    return "Nisan";
                case 5:
                    return "Mayıs";
                case 6:
                    return "Haziran";
                case 7:
                    return "Temmuz";
                case 8:
                    return "Ağustos";
                case 9:
                    return "Eylül";
                case 10:
                    return "Ekim";
                case 11:
                    return "Kasım";
                case 12:
                    return "Aralık";



                default:
                    return "Geçersiz Ay";
            }
        }



    }
}
