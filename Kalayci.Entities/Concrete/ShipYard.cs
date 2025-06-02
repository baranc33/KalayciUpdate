using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class ShipYard : EntityBase, IEntity
    {
        // Tershane Adı En Tepe Tablomuzdur. sadece adı ve projeler bağlantısı olcak
        public string ShipYardName { get; set; } = "Kalaycı Denizcilik";
        
        public string ShipYardManagementName{ get; set; } = "Abdurrahman Kalaycı";
    
        public int? PersonelID { get; set; }  // Tershane Sorumlusu Personel ID'si. Bu ID'ye göre personel bilgileri çekilecek.
        public Personel? Personel{ get; set; }


        //Tershaneye Bağlı projeler burdan çağırılacak
        public ICollection<Project> Projects { get; set; }

    }
}
