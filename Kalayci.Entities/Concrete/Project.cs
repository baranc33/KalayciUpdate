using Kalayci.Shared.Entities.Abstract;


namespace Kalayci.Entities.Concrete
{
    public class Project :EntityBase, IEntity
    {
       // hangi tershaneye bağlı
        public ShipYard shipYard { get; set; }
        public int shipYardId { get; set; }



        // proje adı
        public string ProjectName { get; set; } = "Kalaycı Denizcilik";





        // Proje sorumlusu
        public string UserId { get; set; }
        public KalayciUser User { get; set; }



        //projeye bağlı spool listesi
        public  ICollection<Spool> spoolLists { get; set; }
        public  ICollection<PersonelProject> PersonelProjects { get; set; }





    }
}
