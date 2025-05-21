using Kalayci.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Spool : EntityBase, IEntity
    {
        public string SpoolName { get; set; }
        

        public byte Shipmentlocation { get; set; }// sevk yerini enum cagırcaz

        public byte spoolStatus { get; set; } // spool nerde ? enumdan çağırcaz



        public CircuitList Circuit { get; set; }
        public int CircuitId { get; set; }
    }
}
