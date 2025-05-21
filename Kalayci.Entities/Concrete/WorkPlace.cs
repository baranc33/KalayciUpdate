using Kalayci.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class WorkPlace : EntityBase, IEntity
    {
        public byte Status { get; set; } // enumdan cağırılacak

        public string SpoolCreatedByName{ get; set; }// spoolu imal eden
        public string ArgonMakeByName{ get; set; }// argon kaynağı yapan
        public string GasArcWeldingMakeByName { get; set; }// gas altı kaynağı yapan



    }
}
