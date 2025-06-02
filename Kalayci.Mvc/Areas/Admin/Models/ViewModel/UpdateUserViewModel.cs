using Kalayci.Entities.Concrete;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class UpdateUserViewModel
    {
        public KalayciUser Kalayci { get; set; } 
        public string PersonelId { get; set; }

        public ICollection<Kalayci.Entities.Concrete.Personel> Personels { get; set; } = new List<Kalayci.Entities.Concrete.Personel>();
    }
}
