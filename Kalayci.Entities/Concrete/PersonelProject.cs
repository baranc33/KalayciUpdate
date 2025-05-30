using Kalayci.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Entities.Concrete
{
    public class PersonelProject : EntityBase, IEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PersonelId{ get; set; }
        public Personel Personel { get; set; }
    }
}
