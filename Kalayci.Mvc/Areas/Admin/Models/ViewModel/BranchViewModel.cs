using Kalayci.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel
{
    public class BranchViewModel
    {
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();


        [Required(ErrorMessage = "Branş Adı Zorunludur")]
        [MinLength(3, ErrorMessage = "Branş Adı en az 3 karakterli olmalıdır.")]
        [Display(Name = "Branş Adı")]
        public string BranchName { get; set; }


        [Required(ErrorMessage = "Branş Açıklaması Zorunludur")]
        [MinLength(10, ErrorMessage = "Branş Açıklaması en az 10 karakterli olmalıdır.")]
        [Display(Name = "Branş Açıklama")]
        public string BranchDetay{ get; set; }
    }
}
