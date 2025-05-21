using Kalayci.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class Welding : EntityBase, IEntity
    {
        public byte Status{ get; set; }// enumdan çağırılcak
        public  string WeldingByName{ get; set; }// kaynak yapan kişi
    }
}
