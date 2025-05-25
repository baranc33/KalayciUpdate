using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    // kaynak
    public class Welding : EntityBase, IEntity
    {
        public byte Status{ get; set; }//0 bekliyor - 1 başladı - 2 bitti 

        // burda boru türüne göre kaynak seçenekleri olcak

        public byte SpoolWeldingType { get; set; }


        // daha sonra burda ctor içine göre seçenekler oluşturacağız. 

         





        public int spoolId { get; set; } // hangi spool gönderildi
        public Spool spool { get; set; }




        public string Statu()
        {
            switch (this.Status)//0 1 2
            {
                case 0:
                    return "Bekliyor";
                case 1:
                    return "Başladı";
                case 2:
                    return "Bitti";
                default:
                    return "Bekliyor";
            }

        }
    }
}
