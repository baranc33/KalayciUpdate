using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Spool : EntityBase, IEntity
    {
        //bire çok ilişkiler
        // spoollar projeler bağlı olacak
        public Project Project { get; set; }
        public int ProjectId { get; set; }



        // devre listesinden spoolun devresi alınacak.
        public CircuitList CircuitList { get; set; }
        public int CircuitListId { get; set; }





        public string SpoolName { get; set; }
        public byte spoolStatus { get; set; } // spool nerde ? enumdan çağırcaz
        // 0 atolye -1 kaynakta  - 2 devre teslimde  - 3 sevke hazır -4 tershanede


        // burdan spool idsine göre önce tablolar çağırılır
        // 0 atolye durumu WorkPlace tablosunda
        // 1 kaynak welding Tablosunda
        // 2 devre teslimde CircuitDelivery

        // nereye sevk edilcek Enumdan cağırılacak
        // sevk edilceği yere göre işlemler yapılacakytır.
        public byte Shipmentlocation { get; set; }

        // sevk edilceği yere 




        //bire bir ilişkiler
    



        public WorkPlace WorkPlace { get; set; }
        public Welding Welding { get; set; }
        public CircuitDelivery CircuitDelivery { get; set; }
        public Sending Sending { get; set; }
        public ShipyardAssembly ShipyardAssembly { get; set; }




        // 0 atolye -1 kaynakta  - 2 devre teslimde  - 3 sevke hazır -4 tershanede
        public string WhereIsSpool()
        {
            switch (this.spoolStatus)
            {
                case 0:
                    return "Atolye";
                case 1:
                    return "Kaynakta";
                case 2:
                    return "Devre Teslim";
                case 3:
                    return "Sevk";
                case 4:
                    return "Tershane";
                default:
                    return "Atolye";
            }

        }


    }
}
