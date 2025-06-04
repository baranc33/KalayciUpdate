
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.ImportExcelFiless
{
    public class AddExcelSpoolListViewModel
    {
        public ICollection<ExcelSpoolListViewModel> SpoolList = new List<ExcelSpoolListViewModel>();
        public ICollection<Kalayci.Entities.Concrete.Project> Projects = new List<Kalayci.Entities.Concrete.Project>();

        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string ExcelName{ get; set; }

    }
}
