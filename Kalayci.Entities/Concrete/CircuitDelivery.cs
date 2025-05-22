using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    // devre teslim Durumu
    public class CircuitDelivery: EntityBase, IEntity
    {
        // bu sayfa detayda gözükeceği için seçenekler halinde görünür.
        public bool KaliteKontrol { get; set; }//KaliteKontrol 
        public bool Taslama { get; set; }// Taslama 
        public bool BasıncTesti { get; set; }//BasıncTesti 
        public bool Olculendirme { get; set; }//Olculendirme 
        public bool KaynakTesti { get; set; }//KaynakTesti 

        public int spoolId { get; set; } // hangi spool gönderildi
        public  Spool? spool { get; set; }


         
    }
}
