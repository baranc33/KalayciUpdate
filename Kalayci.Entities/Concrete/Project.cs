using Kalayci.Shared.Entities;


namespace Kalayci.Entities.Concrete
{
    public class Project :EntityBase, IEntity
    {
       
        public string ProjectName{ get; set; }


        public int shipYardId { get; set; }
        public ShipYard shipYard{ get; set; }

        // Projeyi Oluşturan kişi
        public int UserId { get; set; }
        public User User { get; set; }

        //spoollar projeye dahildir
        public  ICollection<Spool> spoolLists { get; set; }
    }
}
