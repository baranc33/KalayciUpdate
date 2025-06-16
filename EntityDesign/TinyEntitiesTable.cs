using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityDesign
{

    public class SpoolStart : MpsBackUpBaseEntity, IMpsEntity
    {

        public string Block { get; set; }
        public string Diameter { get; set; }
        public string TotalKg { get; set; }
        public string Shipmentlocation { get; set; }
        public string SpoolSendingPlace { get; set; }
        public DateTime SpoolAssemblyDateTime { get; set; }
        public string SpoolAssemblyByName { get; set; }
        public string SpoolCreatedByName { get; set; }


        public bool QualityControl { get; set; }//KaliteKontrol True Olursa
        public bool Grinding { get; set; }// Taslama 
        public bool PressureTest { get; set; }//BasıncTesti 
        public bool Dimensioning { get; set; }//Olculendirme 
        public bool WeldingTest { get; set; }//KaynakTesti 

    }


    public class Project : MpsBackUpBaseEntity, IMpsEntity
    {
        public ICollection<Spool> Spools { get; set; }
    }

    public class Spool : MpsTinyBaseEntity, IMpsEntity
    {

        // Veriyi 2ye bölüyoruz.
        // Spool tablosunda Önemli ve küçük verileri Tutmaya özen göstercez.
        // Kalan veriler 1e 1 ilişkide Spool BackUp tablosunda olcak.
        // ilk girelen spoolar IsWork =False


        public Project Project { get; set; }
        public string ProjectId { get; set; }

        // listede görünmesi istenen ve işlem yapılacak veriler
        public string CircuitName { get; set; }
        public string SpoolNo { get; set; }// orjinal Spolun Idsi
        public byte SpoolWeldingType { get; set; } = 0;// spool takip yöntemini belirtecek parametre
        public byte TrackingProperty { get; set; }// spool Takipni yapan




        public string WhereIsSpool()
        {
            SpoolTracking tracking = new SpoolTracking(SpoolWeldingType, TrackingProperty);
            return "";
        }
    }


    public class SpoolTracking
    {

        public bool QualityControla { get; set; }//KaliteKontrol True Olursa
        public bool Grindinga { get; set; }// Taslama 
        public bool PressureTesta { get; set; }//BasıncTesti 
        public bool Dimensioninga { get; set; }//Olculendirme 
        public bool WeldingTesta { get; set; }//KaynakTesti 



        // 0 hepsi false
        // 1 se Sadece QueltiyControl True
        // 2 grinding
        // 3 Queltiy +grindig
        // 5 pressureTest + Qualty
        // 6 pressure  + grindig
        // 7 Qualty+grindig+dpressureTest
        //10 Grinding   Dimensioning
        //11 Dimensioning Grinding QualityControl
        //15 Dimensioning Grinding  PressureTest
        //16 Dimensioning Grinding  PressureTest Dimensioning
        //20 WeldingTest+ Yukardaki verilere göre hesapla
        public void ProgressQuality(bool QualityControl, bool Grinding, bool PressureTest, bool Dimensioning, bool WeldingTest)
        { }
        //byte Value = 0;
        //byte Value2 = 0;
        //byte Value3 = 0;
        //// ilk True ğeri Sıralam 
        //if (QualityControl) { Value+=1; }//  0 1
        //if (Grinding) { Value+=2; }    //   2 3 1
        //if (PressureTest) { Value+=4; } //2 6 7 3 5 1
        //if (Dimensioning) { Value+=8; }//10  16 6  17 7  15 5 11 1
        //if (WeldingTest) { Value+=8; }


        //if (QualityControl)
        //{

        //    Value3+=1;//1           
        //    if (Grinding)
        //    {
        //        Value3+=2;//3
        //                  //
        //        if (PressureTest)
        //        {
        //            Value3+=2;//5
        //            if (Dimensioning)
        //            {
        //                Value3+=8;//13
        //                if (WeldingTest) { Value+=13; } // ful true                        }
        //                else if (Dimensioning) { }

        //            }
        //        }
        //        else if (Dimensioning) { }

        //    }

        //}

        //if (QualityControl && Grinding) // grdinng ve Qulety true 2 Welding  6 
        //{
        //    Value2+=2;
        //    if (WeldingTest) { Value+=4; } // 6
        //    if (Dimensioning) { Value+=5; } // 7 - 13
        //    if (PressureTest) { Value+=1; }// 8  14

        //}
        //else if (!Grinding && !QualityControl)// grindng ve Qualty fals
        //{
        //    Value2+=1;

        //    if (WeldingTest) { Value+=4; } // 5
        //    if (Dimensioning) { Value+=5; } // 6   9
        //    if (PressureTest) { Value+=10; }//16     19 
        //}
        //else if (Grinding) // grinding True Qualty fals
        //{
        //    Value2+=5;
        //    if (WeldingTest) { Value+=4; } // 9 5 
        //    if (Dimensioning) { Value+=5; } // 14 10
        //    if (PressureTest) { Value+=10; }//24   20 
        //}



        private byte _SpoolWeldingType=new() ;
        private byte _TrackingProperty = new();

        public SpoolTracking(byte SpoolWeldingType, byte TrackingProperty)
        {
            //_SpoolWeldingType = SpoolWeldingType;
            //_TrackingProperty = TrackingProperty;
        }

        public void Progress()
        {
            switch (_SpoolWeldingType)
            {
                case 1: // Tig Kaynak
                    ProgressOne();
                    break;
                case 2: // Mag Kaynak
                    ProgressTwo();
                    break;
                case 3: // Argon Kaynak
                    ProgressThree();
                    break;


                default:
                    ProgressDefault();
                    break;
            }

        }

        private byte ProgressDefault()
        {
            if (_SpoolWeldingType == 4)
                return _TrackingProperty;

            return _TrackingProperty++;
        }

        private void ProgressOne() { }
        private void ProgressTwo() { }
        private void ProgressThree() { }

    }
}













