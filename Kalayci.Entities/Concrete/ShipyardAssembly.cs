using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class ShipyardAssembly
    {
        public byte Status { get; set; }
        public string SpoolAssemblyByName { get; set; } //Montajı yapan
        public DateTime SpoolAssemblyDateTime { get; set; } //Montajı yapan
    }
}
