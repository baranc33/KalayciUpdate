using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Point : EntityBase, IEntity
    {

        public byte TeamWorkPoint { get; set; }
        public byte JabTrackingPoint{ get; set; }
        public byte ContinuityPoint { get; set; }

        public byte AveragePoint { get; set; }


        public DateTime GiveDateStart{ get; set; }
        public DateTime GiveDateFinish { get; set; }


        // puanı veren kişi Oluşturan kişi
        public string UserNameGivePoint { get; set; }

        public string UserId { get; set; }

    
        //hangi personel
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

    }
}
