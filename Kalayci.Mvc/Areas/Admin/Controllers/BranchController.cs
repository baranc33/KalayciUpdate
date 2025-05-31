using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using Kalayci.Entities.Concrete;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel;
using Kalayci.Mvc.Areas.Admin.Models.ViewModel.Branch;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Services.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace Kalayci.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BranchController : Controller
    {
        private IBranchService _branchService;
        private IPersonelService _personelService;
        public BranchController(IBranchService branchService, IPersonelService personelService)
        {
            _personelService = personelService;
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBranch(int BranchId)
        {
            Branch branch= await GetBranch(BranchId);

            UpdateBranchViewModel model = new UpdateBranchViewModel
            {
                BranchId = BranchId,
                BranchName=branch.BranchName,
                BranchDetay=branch.BranchDetay

            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchViewModel requestModel)
        {
            Branch branch = await GetBranch(requestModel.BranchId);
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz";
                return RedirectToAction("Index");

            }

            ICollection<Branch> branches = await _branchService.GetAllAsync();

            foreach (var item in branches)
            {
                if(item.BranchName==requestModel.BranchName)
                {
                    TempData["Message"]="Bu Branş Adı Kayıtlıdır.";
                    return RedirectToAction("Index");
                }
            }



            branch.BranchName=requestModel.BranchName;
            branch.BranchDetay=requestModel.BranchDetay;
            branch.ModifiedByName=User.Identity!.Name!;
            branch.ModifiedDate=DateTime.Now;

            await _branchService.UpdateAsync(branch);
            TempData["Message"]=$"{requestModel.BranchName} Branşı Güncellenmiştir";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> BracnhListExport()
        {
            var branch = await _branchService.GetAllAsync(x => x.IsDeleted == false);

            var stream = new MemoryStream();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Branş Listesi");// excel sayfa adı
                worksheet.Cell(1, 1).Value = "Branş Adı"; // 1. satır 1. sütun
                worksheet.Cell(1, 1).Style.Font.Bold = true; // Başlık hücresini kalın yap
                worksheet.Cell(1, 1).Style.Font.FontSize = 20; // Başlık hücresini font boyutunu ayarla 
                                                               //worksheet.Cell(1, 1).FormulaA1 ="";



                worksheet.Cell(1, 2).Value = "Branş Detay"; // 1. satır 2. sütun
                worksheet.Cell(1, 2).Style.Font.Bold = true; // Başlık hücresini kalın yap
                worksheet.Cell(1, 2).Style.Font.FontSize = 20; // Başlık hücresini font boyutunu ayarla

                int row = 2; // Başlık satırından sonra veriler 2. satırdan başlayacak
                foreach (var item in branch)
                {
                    worksheet.Cell(row, 1).Value = item.BranchName; // 2. satır 1. sütun
                    worksheet.Cell(row, 2).Value = item.BranchDetay; // 2. satır 2. sütun
                    row++;
                }
                worksheet.Columns("A").AdjustToContents();// stunun boyutunu otomatik içeriğe göre ayarlar
                worksheet.Columns("B").AdjustToContents();// stunun boyutunu otomatik içeriğe göre ayarlar

                //using (stream = new MemoryStream())
                //{
                workbook.SaveAs(stream); // Excel dosyasını bellekteki akışa kaydet
                stream.Position = 0; // Akışın başlangıcına geri dön
                string fileName = "BranşListesi.xlsx"; // İndirilecek dosya adı
                var content = stream.ToArray();
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


                //}
            }

        }







        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Branch> branches = await GetBranchesAsync();

            BranchViewModel model = new BranchViewModel
            {
                Branches = branches
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchViewModel model)
        {
            ICollection<Branch> branches = await GetBranchesAsync();
            if (!ModelState.IsValid)
            {
                TempData["Message"]="Gerekli Alanları Doldurunuz";
                return View("Index", new BranchViewModel { Branches = branches });
            }


            foreach (var item in branches)
            {
                if (item.BranchName.ToUpper() == model.BranchName.ToUpper())
                {
                    TempData["Message"]="Bu Branş zaten kayıtlı";
                    return View("Index", new BranchViewModel { Branches = branches });
                }
            }


            Branch branch = new Branch
            {
                BranchName = model.BranchName,
                BranchDetay = model.BranchDetay,
                CreatedDate = DateTime.Now,
                ModifiedByName = User!.Identity!.Name!,
                ModifiedDate = DateTime.Now,
                CreatedByName = User.Identity.Name!,
                IsDeleted = false
            };
            await _branchService.AddAsync(branch);



            return RedirectToAction("Index");
        }






        private async Task<ICollection<Branch>> GetBranchesAsync()
        {
            return await _branchService.GetAllAsync(x => x.IsDeleted == false);

        }


        public async Task<IActionResult> RemoveBranch(int BranchId)
        {
            Branch branch = await _branchService.GetAsync(x => x.Id==BranchId);

            ICollection<Personel> personels = await _personelService.GetAllAsync(x => x.branchId==BranchId);
            if (branch != null)
            {
                TempData["Message"]=$"Branşa Bağlı {personels.Count()} personel Bulunmaktadır Silme işlemi yapmadan önce" +
                    $" Branştaki personelleri aktarın";
                return RedirectToAction("Index");

            }
            await _branchService.DeleteAsync(branch);

            return RedirectToAction("Index");
        }



        public async Task<Branch> GetBranch(int id)
        {
            return await _branchService.GetAsync(x => x.Id==id);
        }
    }
}
