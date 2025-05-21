using Kalayci.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class CircuitList : EntityBase, IEntity
    {
        public string CircuitName{ get; set; }
    }
}
