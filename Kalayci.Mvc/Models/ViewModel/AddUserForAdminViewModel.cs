using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;

namespace Kalayci.Mvc.Models.ViewModel
{
    public class AddUserForAdminViewModel
    {
        public UserSaveDto UserSaveDto { get; set; }

        public string PersonelD { get; set; }

        public ICollection<Personel> personels { get; set; } = new List<Personel>();
    }
}
