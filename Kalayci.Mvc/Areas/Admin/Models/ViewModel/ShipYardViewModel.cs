using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class ShipYardViewModel
    {
        public ICollection<Kalayci.Entities.Concrete.ShipYard> ShipYards { get; set; } = new List<Kalayci.Entities.Concrete.ShipYard>();


        [Required(ErrorMessage = "Tersane Adı Zorunludur")]
        [MinLength(10, ErrorMessage = "Tersane Adı en az 10 karakterli olmalıdır.")]
        [Display(Name ="Tersane Adı")]
        public string ShipYardName{ get; set; }

        [Display(Name ="Tersane Yetkilisi")]
        public string ShipYardManagementName { get; set; } = "";
        public int? PersonelID { get; set; }
        public Kalayci.Entities.Concrete.Personel? Personel { get; set; }

        public ICollection<KalayciUser> Users { get; set; } = new List<KalayciUser>();
    }
}
