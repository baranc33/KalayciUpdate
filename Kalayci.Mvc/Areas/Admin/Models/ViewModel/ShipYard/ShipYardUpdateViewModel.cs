using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.ShipYard
{
    public class ShipYardUpdateViewModel
    {
        public int ShipYardID { get; set; }
        [Required(ErrorMessage = " Tersane Adı Zorunludur")]
        [MinLength(10, ErrorMessage = "Tersane Adı en az 10 karakterli olmalıdır.")]
        [Display(Name = "Tersane Adı :")]
        public string ShipYardName { get; set; }

        [Display(Name = "Tersane Sorumlusu:")]
        public string ShipYardManagerName { get; set; } = "";

        public ICollection<KalayciUser>  Users{ get; set; }
        public int? PersonelID { get; set; }  // Tershane Sorumlusu Personel ID'si. Bu ID'ye göre personel bilgileri çekilecek.
        public Kalayci.Entities.Concrete.Personel User { get; set; }

     



    }
}
