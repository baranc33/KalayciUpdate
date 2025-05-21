using Kalayci.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class ShipYard : EntityBase, IEntity
    {
        public string ShipYardName { get; set; }
    }
}
