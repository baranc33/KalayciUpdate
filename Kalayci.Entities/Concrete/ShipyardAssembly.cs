using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{

    // tershane montaj
    public class ShipyardAssembly : EntityBase, IEntity
    {
        public byte Status { get; set; } = 0;
        public  string? SpoolAssemblyByName { get; set; } //Montajı yapan
        public DateTime SpoolAssemblyDateTime { get; set; } //Montajı yapan

        public int spoolId { get; set; } // hangi spool gönderildi
        public Spool spool { get; set; }

        public string Statu()
        {
            switch (this.Status)
            {
                case 0:
                    return "Bekliyor";
                case 1:
                    return "Yapıldı";
                default:
                    return "Bekliyor";
            }

        }
    }
}
