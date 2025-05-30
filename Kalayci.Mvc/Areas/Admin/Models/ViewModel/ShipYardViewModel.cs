using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class ShipYardViewModel
    {
        public ICollection<ShipYard> ShipYards { get; set; } = new List<ShipYard>();


        [Required(ErrorMessage = "Tersane Adı Zorunludur")]
        [MinLength(10, ErrorMessage = "Tersane Adı en az 10 karakterli olmalıdır.")]
        [Display(Name ="Tersane Adı")]
        public string ShipYardName{ get; set; }
    }
}
