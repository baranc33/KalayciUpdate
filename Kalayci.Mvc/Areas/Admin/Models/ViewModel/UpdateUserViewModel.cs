using Kalayci.Entities.Concrete;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class UpdateUserViewModel
    {
        public KalayciUser Kalayci { get; set; } 
        public string PersonelId { get; set; }

        public ICollection<Personel> Personels { get; set; } = new List<Personel>();
    }
}
