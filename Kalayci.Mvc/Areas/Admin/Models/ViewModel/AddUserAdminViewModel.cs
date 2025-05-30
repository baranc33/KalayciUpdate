using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class AddUserAdminViewModel
    {

        public UserSaveDtoAdmin UserSaveDto { get; set; }

        public string PersonelD { get; set; }

        public ICollection<Personel> personels { get; set; }= new List<Personel>();
    }
}
