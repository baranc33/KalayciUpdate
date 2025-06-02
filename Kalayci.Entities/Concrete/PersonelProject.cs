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
        public bool IsActiveWork { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; } = null;
    }
}
