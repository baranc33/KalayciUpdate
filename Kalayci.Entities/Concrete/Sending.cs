using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{

    ///sevk edilme 
    public class Sending : EntityBase, IEntity
    {
        public byte Place { get; set; } = 0; // sevk edilceği yer 
        public byte Status { get; set; } = 0;// sevk edildimi



        public int spoolId { get; set; } // hangi spool gönderildi
        public Spool spool { get; set; }

        public string Statu()
        {
            switch (this.Status)
            {
                case 0:
                    return "Bekliyor";
                case 1:
                    return "Edildi";
                default:
                    return "Bekliyor";
            }

        }
    }
}
