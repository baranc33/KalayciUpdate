using System.ComponentModel.DataAnnotations;

namespace Kalayci.Mvc.Areas.Admin.Models.ViewModel.Personel
{
    public class PersonelAddViewModels
    {

        [Required(ErrorMessage = "Adı Zorunludur")]
        [MinLength(3, ErrorMessage = "Adı en az 3 karakterli olmalıdır.")]
        [Display(Name = "Personel Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soy Adı Zorunludur")]
        [MinLength(2, ErrorMessage = "Soy Adı en az 2 karakterli olmalıdır.")]
        [Display(Name = "Personel Soy Adı")]
        public string LastName { get; set; }




        public enum GenderTypes
        {
            Male,
            Female,
            Unspecified
        }

        [Required(ErrorMessage = "Sicil Numarası Zorunludur")]
        [MinLength(10, ErrorMessage = "Sicil Numarası en az 10 karakterli olmalıdır.")]
        [Display(Name = "Sicil Numarası")]
        public string SgkRegistrationNumber { get; set; }




        [Required(ErrorMessage = "TC Kimlik Numarası Zorunludur")]
        [MinLength(11, ErrorMessage = "TC Kimlik Numarası 11 karakterli olmalıdır.")]
        [MaxLength(11, ErrorMessage = "TC Kimlik Numarası 11 karakterli olmalıdır.")]
        [Display(Name = "TC Kimlik Numarası ")]
        public string TcNumber { get; set; }


        public string Picture { get; set; } = "";


         





        [Required(ErrorMessage = "Cinsiyet Zorunludur")]
        [Display(Name = "Cinsiyet")]
        public bool Gender { get; set; }

 



     



        [Display(Name = "işe Başlama Tarihi")]
        public DateTime WorkStartDate { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Telefon Zorunludur")]
        [MinLength(10, ErrorMessage = "Telefon en az 10 karakterli olmalıdır.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }




        public int branchId { get; set; }
        public ICollection<Entities.Concrete.Branch> branches { get; set; } =  new List<Entities.Concrete.Branch>();

        [Required(ErrorMessage = "Personel Şefi Zorunludur.")]
        [Display(Name = "Personel Şefi")]
        public string ManagerId { get; set; }
        public ICollection<Entities.Concrete.KalayciUser> Manager { get; set; } = new List<Entities.Concrete.KalayciUser>();


        [Display(Name = "Çalıştığı Proje")]
        public int ProjectId { get; set; }
        public ICollection<Entities.Concrete.Project> Projects { get; set; } = new List<Entities.Concrete.Project>();
    }
}
