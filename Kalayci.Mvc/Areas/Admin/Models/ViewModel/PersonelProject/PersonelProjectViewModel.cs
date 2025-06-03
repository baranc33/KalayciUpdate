
namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.PersonelProject
{

    public class PersonelProjectViewModel
    {
        public int ProjectId { get; set; }
        public Kalayci.Entities.Concrete.Project Project { get; set; }
        public int PersonelId { get; set; }
        public Kalayci.Entities.Concrete.Personel Personel { get; set; }

        public bool IsActiveWork { get; set; }
        public int BranchId { get; set; }
        public Kalayci.Entities.Concrete.Branch Branch { get; set; }
        public string ManagerName { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; } = null;
    }
}
