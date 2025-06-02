using Kalayci.Entities.Concrete;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.Project
{
    public class ProjectListViewModel
    {
        public ICollection<Kalayci.Entities.Concrete.Project> Projects { get; set; }
    }
}
