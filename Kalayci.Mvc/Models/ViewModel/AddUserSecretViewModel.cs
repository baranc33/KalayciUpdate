using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Models.ViewModel
{
    public class AddUserSecretViewModel
    {

        public UserSaveDto UserSaveDto { get; set; }

        public string PersonelD { get; set; }

        public ICollection<Personel> personels { get; set; }= new List<Personel>();
    }
}
