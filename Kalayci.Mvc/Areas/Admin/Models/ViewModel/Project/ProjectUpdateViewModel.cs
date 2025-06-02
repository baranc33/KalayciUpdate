using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.Project
{
    public class ProjectUpdateViewModel
    {
        public int ProjectId{ get; set; }


        [Display(Name = "Proje Başlangıç Tarihi")]
        public DateTime ProjectStartTime { get; set; }


        // proje adı
        public string ProjectName { get; set; } = "Kalaycı Denizcilik";





        // Proje sorumlusu
        [Display(Name ="Proje Sorumlusu")]
        public string UserId { get; set; }
        public KalayciUser User { get; set; } = new KalayciUser();

        // hangi tershaneye bağlı
        public Kalayci.Entities.Concrete.ShipYard shipYard { get; set; } = new Kalayci.Entities.Concrete.ShipYard();
        [Display(Name ="Projenin Bağlı olduğu Tersane")]
        public int shipYardId { get; set; }

        public ICollection<Kalayci.Entities.Concrete.KalayciUser> Users { get; set; } = new List<Kalayci.Entities.Concrete.KalayciUser>();
        public ICollection<Kalayci.Entities.Concrete.ShipYard> shipYards { get; set; } = new List<Kalayci.Entities.Concrete.ShipYard>();

    }
}
