using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    // devre teslim Durumu
    public class CircuitDelivery: EntityBase, IEntity
    {
        // bu sayfa detayda gözükeceği için seçenekler halinde görünür.
        public bool QualityControl { get; set; }//KaliteKontrol 
        public bool Grinding { get; set; }// Taslama 
        public bool PressureTest { get; set; }//BasıncTesti 
        public bool Dimensioning { get; set; }//Olculendirme 
        public bool WeldingTest { get; set; }//KaynakTesti 


        public int spoolId { get; set; } // hangi spool gönderildi
        public  Spool spool { get; set; }


         
    }
}
