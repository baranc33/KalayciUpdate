using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.Point;
using Kalayci.Mvc.Areas.Admin.Views.Personel;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IPointService _pointService;
        private readonly IPersonelService _personelService;
        private readonly IPersonelProjectService _personelProjectService;
        private readonly IKalayciUserService _kalayciUserService;
        private readonly IProjectService _projectService;
        public HomeController(IPointService pointService, IPersonelService personelService,
            IPersonelProjectService personelProjectService,
            IKalayciUserService kalayciUserService,
            IProjectService projectService)
        {
            _projectService=projectService;
            _kalayciUserService =kalayciUserService;
            _personelProjectService=personelProjectService;
            _pointService   =pointService;
            _personelService=personelService;
        }


        public async Task<IActionResult> AdminIndex()
        {
            int notification = 0;
            TempData["notification"]=null;
            //şefi atanmamış personeller varmı
            var personels = await _personelService.GetAllAsync(x => x.ManagerUserId==null);

            if (personels.Count()>0)
            {
                TempData["notification"]+="Şef Atanmamış Personeller var";
                notification++;
            }





            var Personels = await _personelService.GetAllAsync(x => x.IsDeleted==false, p => p.PersonelProjects, po => po.points);

            var EmptyProjectPersonel = Personels.Select(x => x.PersonelProjects==null).ToList();
            if (EmptyProjectPersonel.Count()>0)
            {
                TempData["notification"]+="Projeye Atanmamış Personeller var";
                notification++;
            }


            // geçen ayı alcaz
            DateTime StartDateTime = DateTime.Today.AddMonths(-1);
            int day = DateTime.Now.Day -1;
            StartDateTime= StartDateTime.AddDays(-day);
            // elimizde geçen ayın biri var
            DateTime FinishtDateTime = StartDateTime.AddMonths(1).AddDays(-1);


            var EmptyPoin = personels.Select(x => x.points==null).ToList();



            TempData["notificationCount"]=notification.ToString();

            return View();
        }

        // bildirim komutları
        //şefi atanmamış personeller varmı
        // projeye Dahil olmamış personeller varmı.
        // geçen ve önceki ayların puanları girildimi



        [HttpGet]// Hakediş Hesaplama
        public async Task<IActionResult> Entitlement(int PersonelId)
        {
            ICollection<Point> points = await _pointService.GetAllAsync(x => x.PersonelId==PersonelId&&x.GiveDateStart.Year==DateTime.Today.Year, p => p.Personel);
            int TotalTeamWorkPoint = 0;
            int TotalJabTrackingPoint = 0;
            int TotalContinuityPoint = 0;
            int TotalPointCount = points.Count;

            foreach (var item in points)
            {
                TotalTeamWorkPoint+=item.TeamWorkPoint;
                TotalJabTrackingPoint+=item.JabTrackingPoint;
                TotalContinuityPoint+=item.ContinuityPoint;
            }
            PointCalculation model = new PointCalculation(TotalTeamWorkPoint/ points.Count(), TotalJabTrackingPoint / points.Count(), TotalContinuityPoint / points.Count(), TotalPointCount);
            model.PersonelName=points.FirstOrDefault().Personel.Name + " " + points.FirstOrDefault().Personel.LastName;
            model.GetEntitlementMesaj();



            return View(model);
        }


        [HttpGet]// Puan Güncelleme 
        public async Task<IActionResult> UpdatePoint(int PointId)
        {
            Point point = await _pointService.GetAsync(x => x.Id==PointId, p => p.Personel);

            KalayciUser PointUser = await _kalayciUserService.GetAsync(x => x.UserName==point.UserNameGivePoint);
 
            if (point.UserNameGivePoint!=User.Identity.Name  )//istek atan kullanıcı puanı veren kullanıcı değilse
            {
                if(User.HasClaim(x => x.Type==ClaimTypes.Role && x.Value!="Admin"))// kullancı admin değilse
                {
                    return RedirectToAction("Caught", new
                    {
                        PersonelId = point.PersonelId,
                        progress =
                  $"{point.Personel.Name} {point.Personel.LastName} adlı personelin Sizin vermediğiniz Puanını Güncellemeye çalıştınız"
                    });
                }
            }

            PointUpdateViewModel model = new()
            {
                PointId= point.Id,
                TeamWorkPoint=point.TeamWorkPoint,
                JabTrackingPoint=point.JabTrackingPoint,
                ContinuityPoint=point.ContinuityPoint,
                AveragePoint=point.AveragePoint,
                GiveDateStart=point.GiveDateStart,
                GiveDateFinish=point.GiveDateFinish,
                UserNameGivePoint=point.UserNameGivePoint,
                UserId=point.UserId,
                PersonelId=point.PersonelId,
                Users=await _kalayciUserService.GetAllAsync(x => x.IsDeleted==false, p => p.personel)
            };

            return View(model);
        }
        [HttpPost]// Puan Güncelleme 
        public async Task<IActionResult> UpdatePoint(PointUpdateViewModel request)
        {
            
            KalayciUser kalayciUser = await _kalayciUserService.GetAsync(x => x.Id==request.UserId, p => p.personel);
            Point point = await _pointService.GetAsync(x => x.Id==request.PointId,p=>p.Personel);
            if (point.UserNameGivePoint!=User.Identity.Name)//istek atan kullanıcı puanı veren kullanıcı değilse
            {
                if (User.HasClaim(x => x.Type==ClaimTypes.Role && x.Value!="Admin"))// kullancı admin değilse
                {
                    return RedirectToAction("Caught", new
                    {
                        PersonelId = point.PersonelId,
                        progress =
                                 $"{point.Personel.Name} {point.Personel.LastName} adlı personele  Süreklilik Puanını : {request.ContinuityPoint} / iş Takibi Puanı :{request.JabTrackingPoint} / Takım Çalışmasına : {request.TeamWorkPoint} Puan Girmeye Çalıştı"

                    });
                }
            }



            point.TeamWorkPoint= request.TeamWorkPoint;
            point.JabTrackingPoint= request.JabTrackingPoint;
            point.ContinuityPoint= request.ContinuityPoint;
            point.AveragePoint= Convert.ToByte(((request.TeamWorkPoint+request.ContinuityPoint+request.JabTrackingPoint)/3));
            point.GiveDateStart= request.GiveDateStart;
            point.GiveDateFinish= request.GiveDateStart.AddMonths(1).AddDays(-1);
            point.UserNameGivePoint= kalayciUser.UserName;
            point.UserId= request.UserId;
            point.ModifiedByName= User.Identity.Name;
            point.ModifiedDate= DateTime.Now;

            Point personelPointWithUser = await _pointService.GetAsync(x => x.PersonelId==request.PersonelId&&x.GiveDateStart==request.GiveDateStart&&x.UserNameGivePoint==kalayciUser.UserName
             &&x.TeamWorkPoint==point.TeamWorkPoint&&x.ContinuityPoint==point.ContinuityPoint&&x.JabTrackingPoint==point.JabTrackingPoint);

            if (personelPointWithUser!=null)
            {
                TempData["Message"]= "Bilgiler Değiştirilmemiş!";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("UpdatePoint", new { PointId = request.PointId });
            }
          
            await _pointService.UpdateAsync(point);
            TempData["Message"]= "Bilgiler Güncellendi";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("UpdatePoint", new { PointId = request.PointId });

        }



        [HttpGet]// geçmiş Giriş Çıkışlarını gösteren tablo
        public async Task<IActionResult> AllLoginAndLogut(int PersonelId)
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Exit(int PersonelId)
        {
            //puanlar Girilmişmi ?

            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, s => s.points, b => b.branch, u => u.User, up => up.PersonelProjects, u => u.User);

            DateTime StartWorkTime = personel.WorkStartDate;
            int MountDay = StartWorkTime.Day-1;
            StartWorkTime= StartWorkTime.AddDays(-MountDay);

            DateTime ThisDate = DateTime.Now;
            int ThisMountDay = ThisDate.Day-1;
            ThisDate= ThisDate.AddDays(-ThisMountDay);


            TempData["Message"]=null;
            int countMessage = 0;


            //var user = await _kalayciUserService.GetAsync(x => x.UserName==User.Identity.Name);
            while (StartWorkTime<ThisDate.AddMonths(-1))
            {
                ICollection<Point> points = await _pointService.GetAllAsync(x => x.PersonelId==personel.Id && x.GiveDateStart==StartWorkTime);//&&x.UserId==user.Id);

                if (points.Count==0)
                {
                    TempData["Message"]+=$"{StartWorkTime.Year}  {GetMountNameTurkish(StartWorkTime.Month)} ,"+" "+" ";
                    countMessage++;
                }
                //TempData["Message"]+= $"{StartWorkTime.ToString("yyyy-MM-dd")} Tarihli Puanı Girilmemiş. <br/>";
                StartWorkTime= StartWorkTime.AddMonths(1);

            }
            if (countMessage>1)
            {
                TempData["Message"]+=" Aylarının Puanları Girilmemiştir.";
            }
            else if (countMessage==1)
            {
                TempData["Message"]+="Ayının Puanı Girilmemiştir";
            }


            if (TempData["Message"]==null)
            {
                return RedirectToAction("ExitUpdate", new { PersonelId = PersonelId });
            }
            else
            {
                TempData["Message2"]=" Puanları Girdikten Sorna Personelin Çıkışını Yapabilirsiniz.";
                TempData["MessageColor"]="alert-danger";
                TempData["PersonelID"]=PersonelId;
                return View();

            }

        }


        [HttpGet]
        public async Task<IActionResult> ExitUpdate(int PersonelId)
        {
            //await _personelProjectService.

            return View();
        }









        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AllPersonelList()
        {


            ICollection<Personel> Allpersonels = await _personelService.GetAllAsync(x => x.IsDeleted==false,
                B => B.branch,
                p => p.points,
                pp => pp.PersonelProjects
                );


            // geçen ayı alcaz
            DateTime StartDateTime = DateTime.Today.AddMonths(-1);
            int day = DateTime.Now.Day -1;
            StartDateTime= StartDateTime.AddDays(-day);
            // elimizde geçen ayın biri var
            DateTime FinishtDateTime = StartDateTime.AddMonths(1).AddDays(-1);
            TempData["StartDateTime"]=StartDateTime.ToString("yyyy-MM-dd");
            TempData["FinishtDateTime"]=FinishtDateTime.ToString("yyyy-MM-dd");

            return View(Allpersonels);
        }



        [HttpGet]
        public async Task<IActionResult> MyPersonelList()
        {
            KalayciUser Me = await _kalayciUserService.GetAsync(x => x.UserName==User.Identity.Name);
            ICollection<Personel> Mypersonels = await _personelService.GetAllAsync(x => x.ManagerUserId==Me.Id,
                B => B.branch,
                p => p.points,
                pp => pp.PersonelProjects
                );


            // geçen ayı alcaz
            DateTime StartDateTime = DateTime.Today.AddMonths(-1);
            int day = DateTime.Now.Day -1;
            StartDateTime= StartDateTime.AddDays(-day);
            // elimizde geçen ayın biri var
            DateTime FinishtDateTime = StartDateTime.AddMonths(1).AddDays(-1);
            TempData["StartDateTime"]=StartDateTime.ToString("yyyy-MM-dd");
            TempData["FinishtDateTime"]=FinishtDateTime.ToString("yyyy-MM-dd");

            return View(Mypersonels);
        }




        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddPointAdmin(int PersonelId)
        {
            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, s => s.points, b => b.branch, u => u.User, up => up.PersonelProjects, u => u.User);
            PersonelPointViewModel model = new()
            {
                Personel=personel,
                Users=await _kalayciUserService.GetAllAsync(a => a.IsDeleted==false, p => p.personel),
                personelProject=await _personelProjectService.GetAsync(x => x.IsActiveWork==true&&x.PersonelId==PersonelId, pr => pr.Project, p => p.Personel),
                Points=await _pointService.GetAllAsync(x => x.PersonelId==PersonelId, p => p.Personel),
            };
            model.Personel.ManagerUser= await _kalayciUserService.GetAsync(x => x.Id==model.Personel.ManagerUserId, p => p.personel);
            model.Personel.PersonelProjects=await _personelProjectService.GetAllAsync(x => x.IsActiveWork==true&&x.PersonelId==PersonelId, p => p.Project);


            TimeSpan CalcuteWorkTime = DateTime.Now- personel.WorkStartDate;
            int mount = CalcuteWorkTime.Days/30;
            int day = CalcuteWorkTime.Days%30;
            TempData["WorkTime"]=$"{mount} Ay  {day} Gündür Çalışıyor";








            DateTime StartWorkTime = personel.WorkStartDate;
            int MountDay = StartWorkTime.Day-1;
            StartWorkTime= StartWorkTime.AddDays(-MountDay);

            DateTime ThisDate = DateTime.Now;
            int ThisMountDay = ThisDate.Day-1;
            ThisDate= ThisDate.AddDays(-ThisMountDay);


            TempData["Message"]=null;
            int countMessage = 0;


            //var user = await _kalayciUserService.GetAsync(x => x.UserName==User.Identity.Name);
            while (StartWorkTime<ThisDate.AddMonths(-1))
            {
                ICollection<Point> points = await _pointService.GetAllAsync(x => x.PersonelId==personel.Id && x.GiveDateStart==StartWorkTime);//&&x.UserId==user.Id);

                if (points.Count==0)
                {
                    TempData["Message"]+=$"{StartWorkTime.Year}  {GetMountNameTurkish(StartWorkTime.Month)} ,"+" "+" ";
                    countMessage++;
                }
                //TempData["Message"]+= $"{StartWorkTime.ToString("yyyy-MM-dd")} Tarihli Puanı Girilmemiş. <br/>";
                StartWorkTime= StartWorkTime.AddMonths(1);

            }
            if (countMessage>1)
            {
                TempData["Message"]+=" Aylarının Puanları Girilmemiştir.";
            }
            else if (countMessage==1)
            {
                TempData["Message"]+="Ayının Puanı Girilmemiştir";
            }

            //TempData["UserId"] =user.Id;



            return View(model);
        }




        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddPointAdmin(PersonelPointViewModel request)
        {
            KalayciUser AddedUser = await _kalayciUserService.GetAsync(x => x.Id==request.UserId);
            // hangi personele işlem yapıyoruz
            Personel personel = await _personelService.GetAsync(x => x.Id==request.PersonelId, p => p.PersonelProjects);
            // işe başlama tarihinden önceki tarihe veri girişi yaptırmıyoruz
            if (request.GiveDateStart < personel.WorkStartDate.AddDays(-personel.WorkStartDate.Day))
            {
                TempData["Message2"]= $"İşlem Başarısız : İşe Giriş Tarihinden önceki Tarihe Puan Girmeye Çalışıyorsunuz";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPointAdmin", new { PersonelId = request.PersonelId });
            }
            if (request.GiveDateStart>DateTime.Now)
            {
                TempData["Message2"]= $"İşlem Başarısız : ileri Tarihe Puan Giremezsiniz";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPointAdmin", new { PersonelId = request.PersonelId });
            }



            // puan tablomuzu oluşturalım.
            Point point = new()
            {

                CreatedDate=DateTime.Now,
                CreatedByName=User.Identity.Name,
                ModifiedDate=DateTime.Now,
                ModifiedByName=User.Identity.Name,
                IsDeleted=false,
                TeamWorkPoint=request.TeamWorkPoint,
                JabTrackingPoint=request.JabTrackingPoint,
                ContinuityPoint=request.ContinuityPoint,
                AveragePoint=Convert.ToByte(((request.TeamWorkPoint+request.ContinuityPoint+request.JabTrackingPoint)/3)),
                GiveDateStart=request.GiveDateStart,
                GiveDateFinish=request.GiveDateStart.AddMonths(1).AddDays(-1),
                UserNameGivePoint=AddedUser.UserName,
                UserId=request.UserId,
                PersonelId=request.PersonelId
            };

            // bu ay bu kullanıcı puan girmişmi diye kontrol edelim
            Point DataPoint = await _pointService.GetAsync
                 (x => x.PersonelId==request.PersonelId && x.GiveDateStart.Month==point.GiveDateStart.Month && x.GiveDateStart.Year==point.GiveDateStart.Year&&x.UserId==point.UserId);
            if (DataPoint!=null)
            {
                TempData["Message2"]= $"{point.GiveDateStart.Year} {GetMountNameTurkish(point.GiveDateStart.Month)} Ayı İçin Puan Girmişsiniz.   Lütfen Puanı Güncelleyin.";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPointAdmin", new { PersonelId = request.PersonelId });
            }


            //puanı eklemeden önce bi önceki puanı falshe getirelim

            await _pointService.AddAsync(point);
            TempData["Message2"]= $"{point.GiveDateStart.Year} {GetMountNameTurkish(point.GiveDateStart.Month)} Ayı İçin Puan {request.UserNameGivePoint} puan Verilmiştir";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("AddPointAdmin", new { PersonelId = request.PersonelId });
        }


         

        [HttpGet]
        public async Task<IActionResult> Caught(int PersonelId, string progress)
        {
            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, s => s.points, b => b.branch, u => u.User, up => up.PersonelProjects, u => u.User, m => m.ManagerUser);

            KalayciUser user = await _kalayciUserService.GetAsync(x => x.UserName==User.Identity.Name, p => p.personel);
            CaughtViewModel model = new CaughtViewModel()
            {
                CreatedDate=DateTime.Now,
                ModifiedDate=DateTime.Now,
                IsDeleted=false,
                CreatedByName = User.Identity.Name,
                ModifiedByName = User.Identity.Name,
                CaughtUserName = user.UserName,
                CaughtUserId = user.Id,
                CaughtPersonelName =user.personel.Name + " " +user.personel.LastName,
                PersonelId = PersonelId,
                WhicProggress = progress
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddPoint(int PersonelId)
        {



            Personel personel = await _personelService.GetAsync(x => x.Id==PersonelId, s => s.points, b => b.branch, u => u.User, up => up.PersonelProjects, u => u.User, m => m.ManagerUser);

            if (personel.ManagerUser.UserName!=User.Identity.Name)
            {
                return RedirectToAction("Caught", new { PersonelId = PersonelId, progress = $"{personel.ManagerUser.UserName}  Kullanıcısının Personel Puan Detay Sayfasına Giriş Yapmaya Çalıştız" });
            }

            PersonelPointViewModel model = new()
            {
                Personel=personel,
                personelProject=await _personelProjectService.GetAsync(x => x.IsActiveWork==true&&x.PersonelId==PersonelId, pr => pr.Project, p => p.Personel),
                Points=await _pointService.GetAllAsync(x => x.PersonelId==PersonelId, p => p.Personel),
            };
            model.Personel.ManagerUser= await _kalayciUserService.GetAsync(x => x.Id==model.Personel.ManagerUserId, p => p.personel);
            model.Personel.PersonelProjects=await _personelProjectService.GetAllAsync(x => x.IsActiveWork==true&&x.PersonelId==PersonelId, p => p.Project);

            TimeSpan CalcuteWorkTime = DateTime.Now- personel.WorkStartDate;
            int mount = CalcuteWorkTime.Days/30;
            int day = CalcuteWorkTime.Days%30;
            TempData["WorkTime"]=$"{mount} Ay  {day} Gündür Çalışıyor";








            DateTime StartWorkTime = personel.WorkStartDate;
            int MountDay = StartWorkTime.Day-1;
            StartWorkTime= StartWorkTime.AddDays(-MountDay);

            DateTime ThisDate = DateTime.Now;
            int ThisMountDay = ThisDate.Day-1;
            ThisDate= ThisDate.AddDays(-ThisMountDay);


            TempData["Message"]=null;
            int countMessage = 0;


            var user = await _kalayciUserService.GetAsync(x => x.UserName==User.Identity.Name);
            while (StartWorkTime<ThisDate.AddMonths(-1))
            {
                ICollection<Point> points = await _pointService.GetAllAsync(x => x.PersonelId==personel.Id && x.GiveDateStart==StartWorkTime);//&&x.UserId==user.Id);

                if (points.Count==0)
                {
                    TempData["Message"]+=$"{StartWorkTime.Year}  {GetMountNameTurkish(StartWorkTime.Month)} ,"+" "+" ";
                    countMessage++;
                }
                //TempData["Message"]+= $"{StartWorkTime.ToString("yyyy-MM-dd")} Tarihli Puanı Girilmemiş. <br/>";
                StartWorkTime= StartWorkTime.AddMonths(1);

            }
            if (countMessage>1)
            {
                TempData["Message"]+=" Aylarının Puanları Girilmemiştir.";
            }
            else if (countMessage==1)
            {
                TempData["Message"]+="Ayının Puanı Girilmemiştir";
            }


            TempData["UserId"] =user.Id;



            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> AddPoint(PersonelPointViewModel request)
        {
            // hangi personele işlem yapıyoruz
            Personel personel = await _personelService.GetAsync(x => x.Id==request.PersonelId, p => p.PersonelProjects);


            if (personel.ManagerUser.UserName!=User.Identity.Name)
            {
                return RedirectToAction("Caught", new
                {
                    PersonelId = request.PersonelId,
                    progress =
                    $"{personel.Name} {personel.LastName} adlı personele  Süreklilik Puanını : {request.ContinuityPoint} / iş Takibi Puanı :{request.JabTrackingPoint} / Takım Çalışmasına : {request.TeamWorkPoint} Puan Girmeye Çalıştı"
                });
            }


            // işe başlama tarihinden önceki tarihe veri girişi yaptırmıyoruz
            if (request.GiveDateStart < personel.WorkStartDate.AddDays(-personel.WorkStartDate.Day))
            {
                TempData["Message2"]= $"İşlem Başarısız : İşe Giriş Tarihinden önceki Tarihe Puan Girmeye Çalışıyorsunuz";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPoint", new { PersonelId = request.PersonelId });
            }
            // projeye atanma tarihinden önceye sadece bilgi işlem puan atiyabilir.
            int day = personel.PersonelProjects.FirstOrDefault(x => x.IsActiveWork==true).StartDate.Day;
            if (request.GiveDateStart < personel.PersonelProjects.FirstOrDefault(x => x.IsActiveWork==true).StartDate.AddDays(-day))
            {

                TempData["Message2"]= $"İşlem Başarısız : Projeye Atanma Tarihinden önceki Tarihe Puan Girmeye Çalışıyorsunuz. Bu işlemi Bilgi işlem Yapabilir";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPoint", new { PersonelId = request.PersonelId });
            }
            if (request.GiveDateStart>DateTime.Now)
            {
                TempData["Message2"]= $"İşlem Başarısız : ileri Tarihe Puan Giremezsiniz";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPoint", new { PersonelId = request.PersonelId });
            }



            // puan tablomuzu oluşturalım.
            Point point = new()
            {

                CreatedDate=DateTime.Now,
                CreatedByName=User.Identity.Name,
                ModifiedDate=DateTime.Now,
                ModifiedByName=User.Identity.Name,
                IsDeleted=false,
                TeamWorkPoint=request.TeamWorkPoint,
                JabTrackingPoint=request.JabTrackingPoint,
                ContinuityPoint=request.ContinuityPoint,
                AveragePoint=Convert.ToByte(((request.TeamWorkPoint+request.ContinuityPoint+request.JabTrackingPoint)/3)),
                GiveDateStart=request.GiveDateStart,
                GiveDateFinish=request.GiveDateStart.AddMonths(1).AddDays(-1),
                UserNameGivePoint=User.Identity.Name,
                UserId=request.UserId,
                PersonelId=request.PersonelId
            };

            // bu ay bu kullanıcı puan girmişmi diye kontrol edelim
            Point DataPoint = await _pointService.GetAsync
                 (x => x.PersonelId==request.PersonelId && x.GiveDateStart.Month==point.GiveDateStart.Month && x.GiveDateStart.Year==point.GiveDateStart.Year&&x.UserId==point.UserId);
            if (DataPoint!=null)
            {
                TempData["Message2"]= $"{point.GiveDateStart.Year} {GetMountNameTurkish(point.GiveDateStart.Month)} Ayı İçin Puan Girmişsiniz. <br/> Lütfen Puanı Güncelleyin.";
                TempData["MessageColor"]="alert-danger";
                return RedirectToAction("AddPoint", new { PersonelId = request.PersonelId });
            }


            await _pointService.AddAsync(point);
            TempData["Message2"]= $"{point.GiveDateStart.Year} {GetMountNameTurkish(point.GiveDateStart.Month)} Ayı İçin Puan {request.UserNameGivePoint} puan Verilmiştir";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("AddPoint", new { PersonelId = request.PersonelId });
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
