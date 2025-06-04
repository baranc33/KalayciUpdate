 using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    // devre isimleri
    public class CircuitList : EntityBase, IEntity
    {
        public string CircuitName{ get; set; }
        //public ICollection<Spool> spoolLists { get; set; }

    }
}
