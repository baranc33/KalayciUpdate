using ClosedXML.Excel;
using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.ImportExcelFiless;
using Kalayci.Services.Abstract.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminManagmentController : Controller
    {

        private IPersonelService _personelService;
        private IBranchService _branchService;
        private IKalayciUserService _kalayciUserService;
        private IProjectService _projectService;
        private IPersonelProjectService _personelProjectService;
        private IPointService _pointService;
        private ISpoolService _spoolService;
        public AdminManagmentController(IPersonelService personelService, IBranchService branchService,
            IKalayciUserService kalayciUserService,
            IPersonelProjectService personelProjectService,
            IProjectService projectService,
            IPointService pointService,
            ISpoolService spoolService)
        {
            _spoolService = spoolService;
            _pointService = pointService;
            _personelProjectService=personelProjectService;
            _projectService =projectService;
            _kalayciUserService = kalayciUserService;
            _branchService =branchService;
            _personelService = personelService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> EmptyProjectPersonelFill()
        {

            bool result = await _personelProjectService.AutomaticPersonFiilProject();
            TempData["Message"] = "Personel Proje Atama işlemi Başarılı";
            TempData["MessageColor"]="alert-success";
            return RedirectToAction("Index");
        }





        [HttpGet]//test kodudur 
        public IActionResult ImportExcel()
        {
            return View();
        }



        [HttpPost]//test kodudur 
        public async Task<IActionResult> ImportExcel(IFormFile formFile)
        {

            if (formFile!=null)
            {
                var fileName = Path.GetFileName(formFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Excel", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("ShowExcel");
        }

        // test kodudur 

        [HttpGet]
        public IActionResult ShowExcel()
        {
            string filePath = "C:\\Users\\baran\\source\\repos\\KalayciUpdate\\Kalayci.Mvc\\wwwroot\\Excel\\KPS_SPOOL TAKiP_LİSTESi.xlsx";

            var dataTable = new DataTable();
            using (var workBook = new XLWorkbook(filePath))
            {
                var workSheet = workBook.Worksheet(1); // İlk sayfayı al
                var range = workSheet.RangeUsed(); // Kullanılan aralığı al
                foreach (var cell in range.Row(1).Cells())
                {
                    dataTable.Columns.Add(cell.GetValue<string>()); // İlk satırdaki hücreleri sütun olarak ekle
                }

                int rowCount = range.RowCount();
                // kaçıncı rowdan başlicağını seçioz "i" değeri olarak
                for (int i = 2; i <= rowCount; i++)
                {//satır değiştrip her satır için stun giriyoruz.
                    var dataRow = dataTable.NewRow();
                    var cellRow = range.Row(i);
                    for (int cell = 1; cell<=dataTable.Columns.Count; cell++)
                    {
                        dataRow[cell-1]=cellRow.Cell(cell).Value; // Hücre değerlerini satıra ekle
                        //dataRow[cell-1]=cellRow.Cell(cell).GetValue<string>(); // Hücre değerlerini satıra ekle
                    }
                    dataTable.Rows.Add(dataRow); // Satırı tabloya ekle
                }

            }


            return View();
        }





        [HttpGet]
        public IActionResult MpsGroupIMportExcelForSpoolList()
        {

            AddExcelSpoolListViewModel model = new AddExcelSpoolListViewModel();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> MpsGroupIMportExcelForSpoolList(IFormFile formFile)
        {
           

            var fileName = "";

            AddExcelSpoolListViewModel model = new AddExcelSpoolListViewModel();
            if (formFile!=null)
            {
                var rand = new Random();
                var uid = rand.Next(1, 1000000);
                fileName = Path.GetFileName(uid+formFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Excel", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                using (var workBook = new XLWorkbook(filePath))
                {
                    var workSheet = workBook.Worksheet(1); // İlk sayfayı al
                    var range = workSheet.RangeUsed(); // Kullanılan aralığı al


                    int rowCount = range.RowCount();
                    // kaçıncı rowdan başlicağını seçioz "i" değeri olarak
                    for (int i = 2; i <= rowCount; i++)
                    {//satır değiştrip her satır için stun giriyoruz.
                        var cellRow = range.Row(i);

                        ExcelSpoolListViewModel excelSpoolListViewModel = new ExcelSpoolListViewModel();
                        excelSpoolListViewModel.No = cellRow.Cell(1).GetValue<string>();
                        excelSpoolListViewModel.Block = cellRow.Cell(2).GetValue<string>();
                        excelSpoolListViewModel.CircutName = cellRow.Cell(3).GetValue<string>();
                        excelSpoolListViewModel.SpoolNo = cellRow.Cell(4).GetValue<string>();
                        excelSpoolListViewModel.Diameter = cellRow.Cell(5).GetValue<string>();
                        excelSpoolListViewModel.TotalKg= (cellRow.Cell(6).GetValue<string>()).Replace(',', '.');
                      
                        if (!String.IsNullOrEmpty(excelSpoolListViewModel.SpoolNo))
                        {
                            model.SpoolList.Add(excelSpoolListViewModel);
                        }

                    }

                }
            }
            model.Projects = await _projectService.GetAllAsync(x => x.IsDeleted == false, p => p.shipYard);
            model.ExcelName = fileName;
            return View(model);
        }


        [HttpGet]
        public IActionResult MpsGroupAddDatabaseExcelForSpoolList()
        {
            return View();
        }
        // orjinal kod test amaçlı yorum satırı haline getirildi
        //[HttpPost]
        //public async Task<IActionResult> MpsGroupAddDatabaseExcelForSpoolList(AddExcelSpoolListViewModel model)
        //{
        //    if (model.ProjectId==0)
        //    {
        //        TempData["Message"]="Proje Seçmediniz. Tekradan Yükleme Yapmalısınız.";
        //        TempData["MessageColor"]="alert-danger";
        //        return View();

        //    }
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Excel", model.ExcelName);

        //    ICollection<Spool> spoolLists = new List<Spool>();
        //    //var dataTable = new DataTable();
        //    using (var workBook = new XLWorkbook(filePath))
        //    {
        //        var workSheet = workBook.Worksheet(1); // İlk sayfayı al
        //        var range = workSheet.RangeUsed(); // Kullanılan aralığı al


        //        int rowCount = range.RowCount();
        //        // kaçıncı rowdan başlicağını seçioz "i" değeri olarak
        //        for (int i = 2; i <= rowCount; i++)
        //        {//satır değiştrip her satır için stun giriyoruz.
        //            var cellRow = range.Row(i);


        //            Spool spool = new Spool()
        //            {
        //                ProjectId= model.ProjectId,
        //                CircuitName=cellRow.Cell(3).GetValue<string>(),
        //                SpoolName=cellRow.Cell(4).GetValue<string>(),
        //                spoolStatus= 0, // başlangıçta atölyede
        //                Shipmentlocation="Bilinmiyor",
        //                No =  cellRow.Cell(1).GetValue<string>(),
        //                Block = cellRow.Cell(2).GetValue<string>(),
        //                Diameter = cellRow.Cell(5).GetValue<string>(),
        //                TotalKg = cellRow.Cell(6).GetValue<string>(),
        //                CreatedByName = User.Identity.Name,
        //                ModifiedByName = User.Identity.Name
        //            };

        //            if (!String.IsNullOrEmpty(spool.SpoolName))
        //            {
        //                spoolLists.Add(spool);
        //            }

        //        }

        //    }

        //    var result = await _spoolService.AddRangeSpoolistAsyncAutomatikExcelList(spoolLists);

        //    if (result.Item1)
        //    {
        //        TempData["Message"] = $"{result.Item2}";
        //        TempData["MessageColor"] = "alert-success";
        //    }
        //    else
        //    {
        //        TempData["Message"] = $"{result.Item2}";
        //        TempData["MessageColor"] = "alert-danger";
        //    }

        //    return View(model);
        //}

        // değişitirilmiş kod blok , no , Dn , değerleri üstünde işlem yapabilmek amaçlıdır.
        [HttpPost]
        public async Task<IActionResult> MpsGroupAddDatabaseExcelForSpoolList(AddExcelSpoolListViewModel model)
        {
            if (model.ProjectId==0)
            {
                TempData["Message"]="Proje Seçmediniz. Tekradan Yükleme Yapmalısınız.";
                TempData["MessageColor"]="alert-danger";
                return View();

            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Excel", model.ExcelName);

            ICollection<Spool> spoolLists = new List<Spool>();
            //var dataTable = new DataTable();
            using (var workBook = new XLWorkbook(filePath))
            {
                var workSheet = workBook.Worksheet(1); // İlk sayfayı al
                var range = workSheet.RangeUsed(); // Kullanılan aralığı al


                int rowCount = range.RowCount();
                // kaçıncı rowdan başlicağını seçioz "i" değeri olarak
                for (int i = 2; i <= rowCount; i++)
                {//satır değiştrip her satır için stun giriyoruz.
                    var cellRow = range.Row(i);

                     
                    Spool spool = new Spool()
                    {
                        ProjectId= model.ProjectId,
                        CircuitName=cellRow.Cell(3).GetValue<string>(),
                        SpoolName=cellRow.Cell(4).GetValue<string>(),
                        spoolStatus= 0, // başlangıçta atölyede
                        Shipmentlocation="Bilinmiyor",
                        No =  cellRow.Cell(1).GetValue<string>(),
                        Block = cellRow.Cell(2).GetValue<string>(),
                        Diameter = cellRow.Cell(5).GetValue<string>(),
                        TotalKg = cellRow.Cell(6).GetValue<string>(),
                        CreatedByName = User.Identity.Name,
                        ModifiedByName = User.Identity.Name
                    };

                    if (!String.IsNullOrEmpty(spool.SpoolName))
                    {
                        spoolLists.Add(spool);
                    }

                }

            }

            var result= await _spoolService.AddRangeSpoolistAsyncAutomatikExcelList(spoolLists);

            if (result.Item1)
            {
                TempData["Message"] = $"{result.Item2}";
                TempData["MessageColor"] = "alert-success";
            }
            else
            {
                TempData["Message"] = $"{result.Item2}";
                TempData["MessageColor"] = "alert-danger";
            }

            return View(model);
        }




    }
}
