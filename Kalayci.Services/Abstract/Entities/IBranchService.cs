using Kalayci.Data.Migrations;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{

    //public class BranchViewModel
    //{
    //    public string IsDelete { get; set; }
    //    public string Id { get; set; }
    //    public string LastBackUpId { get; set; } = "Bilgi işlem";

    //    public int PersonelCount { get; set; }
    //    public string BranchName { get; set; } = "Bilgi işlem";
    //    public string BranchDetay { get; set; } = "Detay Verisi";

    //}
    //    public class BraanchListWieModel
    //{
    //public int BranchPassiveCount { get; set; }
    //    public int BranchActiveCount { get; set; }
    //    ICollection<BranchViewModel> branchs { get; set; }
    //}
    public interface IBranchService : IGenericService<Branch>
    {

        //        Task<BraanchListWieModel> GetAllBranchAsync(bool AllList, bool IsDelete);
        Task<ICollection<Branch>> GetBranchesAsyncOrderByName();


        //        Task<ICollection<Branch>> GetBranchesAsyncOrderByName(bool Valu);
    }
}
