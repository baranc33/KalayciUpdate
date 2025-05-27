using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class AddUserViewModel
    {

        public UserSaveDto UserSaveDto { get; set; }

        public int PersonelD { get; set; }

        public ICollection<Personel> personels { get; set; }= new List<Personel>();
    }
}
