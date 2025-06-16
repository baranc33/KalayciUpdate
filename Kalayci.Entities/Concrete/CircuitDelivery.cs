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


        public string Statu()
        {
            string Message ="";

            if (!QualityControl) Message += " Kalite Kontrol , ";
            if (!Grinding) Message += " Taslama , ";
            if (!PressureTest) Message += " Basınç Testi , ";
            if (!Dimensioning) Message += " Ölçülendirme , ";
            if (!WeldingTest) Message += " Kaynak Testi , ";

            string MessageClear = Message.Remove(Message.Length-1);
            MessageClear+=" işlemleri Yapılmadı.";

            return MessageClear;
        }
    }
}
