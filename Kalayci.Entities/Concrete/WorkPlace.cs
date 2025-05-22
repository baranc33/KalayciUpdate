using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class WorkPlace : EntityBase, IEntity
    {
        public byte Status { get; set; } = 0; // 0 Bekliyor - 1 başladı  -2 bitti
         


        public string? SpoolCreatedByName{ get; set; }// spoolu yapan usta


        public int spoolId { get; set; } // hangi spool gönderildi
        public Spool? spool { get; set; }

        public string Statu()
        {
           switch (this.Status)
            {
                case 0:
                    return "Bekliyor";
                case 1:
                    return "Başladı";
                case 2:
                    return "Bitti";
                default:
                    return "Bilinmiyor";
            }

        }

    }
}
