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
        public byte SavePoint{ get; set; }

        public DateTime GiveDate{ get; set; }


        // puanı veren kişi Oluşturan kişi
        public string UserGivePoint { get; set; }

        public string UserId { get; set; }

    
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

    }
}
