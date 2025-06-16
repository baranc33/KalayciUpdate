using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.Spool
{
    public class ProjectSpoolListViewModel
    {


        public int ProjectId { get; set; }
        public int WorkPersonelCount { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string shipYardName { get; set; }
        public DateTime ProjectStartTime { get; set; }  
        public DateTime? ProjectFinishTime { get; set; } = null; // proje bitiş tarihi opsiyonel olabilir. çünkü bitmeyen projeler var.


        // Proje sorumlusu
        public string UserId { get; set; }
        public KalayciUser User { get; set; }
        public ProjectPercentageCalculate projectPercentageCalculate = new ProjectPercentageCalculate();

        //public ICollection<Kalayci.Entities.Concrete.Personel> PersonelProjects { get; set; }= new List<Kalayci.Entities.Concrete.Personel>();
        public ICollection<Kalayci.Entities.Concrete.Spool> Spools { get; set; } = new List<Kalayci.Entities.Concrete.Spool>();
    }
}
