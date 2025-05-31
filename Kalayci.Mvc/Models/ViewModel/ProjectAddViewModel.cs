using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Models.ViewModel
{
    public class ProjectAddViewModel
    {
        [Required(ErrorMessage = "Yetkili Personel Zorunludur")]
        [Display(Name = "Proje Sorumlusu")]
        public string UsersId { get; set; }
        [Required(ErrorMessage = "Bağlı olduğu Tersane Zorunludur")]
        [Display(Name = "Bağlı olduğu Tersane")]
        public string ShipYardNameDto { get; set; }

        [Required(ErrorMessage = "Proje Adı Zorunludur")]
        [MinLength(3, ErrorMessage = "Proje Adı en az 3 karakterli olmalıdır.")]
        [Display(Name = "Proje Adı")]
        public string ProjectNameDto { get; set; }



        public ICollection<KalayciUser> Users { get; set; } = new List<KalayciUser>();
        public ICollection<ShipYard> ShipYards { get; set; } = new List<ShipYard>();

        public Project Project { get; set; } = new Project();
    }
}
